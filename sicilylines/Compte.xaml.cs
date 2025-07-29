using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace sicilylines;

public partial class Compte : ContentPage
{
    Client cli = null;
    public Compte(Client clientus)
	{
        cli = clientus;
        InitializeComponent();
        loadDataFromAPI(clientus);
	}

    private void loadDataFromAPI(Client cli)
    {

        try
        {
            PseudoEntry.Text = cli.Pseudo;
            AddressEntry.Text = cli.Adresse;
            PostalCodeEntry.Text = cli.Cp;
            PhoneEntry.Text = cli.Tel;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task<bool> UpdateClientAsync(Client client, string newAddress, string newPhone)
    {
        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Préparer l'objet client avec les nouvelles valeurs
                client.Adresse = newAddress;
                client.Tel = newPhone;

                // URL de l'API pour la mise à jour
                string url = $"http://localhost:5066/usersitems?num={newPhone}&adr={newAddress}";

                // Sérialiser l'objet client
                string jsonContent = JsonConvert.SerializeObject(client);

                // Préparer le contenu de la requête
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Envoyer la requête PUT
                HttpResponseMessage response = await httpClient.PutAsync(url, content);

                // Vérifier si la requête a réussi
                return response.IsSuccessStatusCode;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la mise à jour du client : {ex.Message}");
            return false;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(AddressEntry.Text) && !string.IsNullOrEmpty(PhoneEntry.Text))
            {
                bool success = await UpdateClientAsync(cli, AddressEntry.Text, PhoneEntry.Text);

                if (success)
                {
                    await DisplayAlert("Succès", "Vos informations ont été mises à jour", "OK");
                    // Mettre à jour l'objet client local
                    cli.Adresse = AddressEntry.Text;
                    cli.Tel = PhoneEntry.Text;
                }
                else
                {
                    await DisplayAlert("Erreur", "Impossible de mettre à jour vos informations", "OK");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Coordonnées manquantes", "Retour");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
        }


    }
}