namespace API_Client
{
   
        public class Client
        {
            private int id_client;
        private string nom;
        private string prenom;
        private string pseudo;
        private string password;
        private string adresse;
            private string cp;
            private string tel;

            public Client(int id_client, string nom, string prenom, string pseudo, string password, string adresse, string cp, string tel)
            {
                this.Id_client = id_client;
                this.Pseudo = nom;
                this.Password = prenom;
                this.Nom = pseudo;
                this.Prenom = password;
                this.Adresse = adresse;
                this.Cp = cp;
                this.Tel = tel;
            }

            public int Id_client { get => id_client; set => id_client = value; }
            public string Pseudo { get => pseudo; set => pseudo = value; }
            public string Password { get => password; set => password = value; }
            public string Nom { get => nom; set => nom = value; }
            public string Prenom { get => prenom; set => prenom = value; }
            public string Adresse { get => adresse; set => adresse = value; }
            public string Cp { get => cp; set => cp = value; }
            public string Tel { get => tel; set => tel = value; }
        }
    }
