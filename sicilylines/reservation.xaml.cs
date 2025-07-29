using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace sicilylines;

public partial class reservation : ContentPage
{

    public reservation(Client cli)
    {
        InitializeComponent();
        
        loadDataFromAPIfutur(cli);
    }

    private async void loadDataFromAPIfutur(Client cli)
    {

        try
        {
            HttpClient client = new HttpClient();
            var restURL = "http://localhost:5066/traverseitems/" + cli.Id_client;
            client.BaseAddress = new Uri(restURL);
            HttpResponseMessage response = await client.GetAsync(restURL);
            var content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<Traverse>>(content);

            var (traverseesPassees, traverseesFutures) = Tritraverse(Items);
            

            FutureReservationsListView.ItemsSource = traverseesFutures;
            PastReservationsListView.ItemsSource = traverseesPassees;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private (List<Traverse> TraverseesPassees, List<Traverse> TraverseesFutures) Tritraverse(List<Traverse> items)
    {
        List<Traverse> avant = new List<Traverse>();
        List<Traverse> apres = new List<Traverse>();

        DateTime today = DateTime.Today;


        foreach (Traverse traverse in items)
        {
            // Convertir la chaîne de date en objet DateTime
            if (DateTime.TryParse(traverse.DATETRAVERSE.ToString(), out DateTime dateTraverse))
            {
                if (dateTraverse >= today)
                {
                    apres.Add(traverse);
                }
                else
                {
                    avant.Add(traverse);
                }
            }
        }

        return (avant, apres);
    }
}