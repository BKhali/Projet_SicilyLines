using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace API_Client
{
   public class ClientDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "slines";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Mise à jour d'un client

        public static void updateClient(Client u, int num, string adr)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("UPDATE client set tel = " + num + ", adresse = '" + adr + "' WHERE ID_CLIENT = " + u.Id_client);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        // Mise à jour d'un client

        public static void insertUser(Client u)
                {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();

                string req = "insert into User values (" + u.Id_client + ", '"+ u.Nom +"' , '"+ u.Prenom +"' ,'"+ u.Pseudo + "','"+ u.Password+"', '"+u.Adresse+"', '"+u.Cp+"', '"+u.Tel+"')";


                Ocom = maConnexionSql.reqExec(req);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        // Mise à jour d'un client

        /*
        public static Client trouveClient(int id)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();

                string req = "Select * from client where ID_CLIENT = " + id;

                Ocom = maConnexionSql.reqExec(req);

                MySqlDataReader reader = Ocom.ExecuteReader();

                Client u = null;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom= (string)reader.GetValue(2);
                    string pseudo = (string)reader.GetValue(3);
                    string password = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string cp = (string)reader.GetValue(6);
                    string tel = (string)reader.GetValue(7);


                    //Instanciation d'un Client
                    u = new Client(num,nom,prenom,pseudo,password,adresse,cp,tel);

                }

                // fermeture du reader
                reader.Close();

                //fermeture de la connexion
                maConnexionSql.closeConnection();

                // Envoi de client
                return (u);


            }

            catch (Exception ex)
            {

                throw (ex);

            }

        }

        */

        public static Client trouveClientpseudo(string pseudoo)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();

                string req = "Select * from client where pseudo = '" + pseudoo + "'";

                Ocom = maConnexionSql.reqExec(req);

                MySqlDataReader reader = Ocom.ExecuteReader();

                Client u = null;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string pseudo = (string)reader.GetValue(3);
                    string password = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string cp = (string)reader.GetValue(6);
                    string tel = (string)reader.GetValue(7);


                    //Instanciation d'un Client
                    u = new Client(num, nom, prenom, pseudo, password, adresse, cp, tel);

                }

                // fermeture du reader
                reader.Close();

                //fermeture de la connexion
                maConnexionSql.closeConnection();

                // Envoi de client
                return (u);


            }

            catch (Exception ex)
            {

                throw (ex);

            }

        }

        // Récupération de la liste des Clients
        public static List<Client> getUsers()
        {

            List<Client> lc = new List<Client>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("Select * from client");

// lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Client u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string pseudo = (string)reader.GetValue(3);
                    string password = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string cp = (string)reader.GetValue(6);
                    string tel = (string)reader.GetValue(7);

                    //Instanciation d'un Client
                    u = new Client(num, nom, prenom, pseudo, password, adresse, cp, tel);

                    // Ajout de ce client à la liste 
                    lc.Add(u);


                }


                // fermeture du reader
                reader.Close();

                //fermeture de la connexion
                maConnexionSql.closeConnection();

                // Envoi de la liste
                return (lc);


            }

            catch (Exception emp)
            {

                throw (emp);

            }

           
        }

    }




}

