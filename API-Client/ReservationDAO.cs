using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace API_Client
{
   public class ReservationDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "slines";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        public static List<Reservation> getReservationfutur(int cli)
        {

            List<Reservation> lc = new List<Reservation>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("SELECT * FROM traverse t JOIN reservation r ON t.ID_LIAISON = r.ID_LIAISON AND t.ID_TRAVERSE = r.ID_TRAVERSE WHERE r.ID_CLIENT = " + cli + " AND CONCAT(t.DATETRAVERSE, ' ', t.HEURE) > NOW();");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Reservation u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_RESERVATION = (int)reader.GetValue(6);
                    int ID_LIAISON = (int)reader.GetValue(7);
                    int ID_TRAVERSE = (int)reader.GetValue(8);
                    int ID_CLIENT = (int)reader.GetValue(9);
                    string Nomres = (string)reader.GetValue(10);

                    //Instanciation d'un Client
                    u = new Reservation(ID_RESERVATION, ID_LIAISON, ID_TRAVERSE, ID_CLIENT, Nomres);

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

        public static List<Reservation> getReservationpasse(int cli)
        {

            List<Reservation> lc = new List<Reservation>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("SELECT * FROM traverse t JOIN reservation r ON t.ID_LIAISON = r.ID_LIAISON AND t.ID_TRAVERSE = r.ID_TRAVERSE WHERE r.ID_CLIENT = " + cli + " AND CONCAT(t.DATETRAVERSE, ' ', t.HEURE) < NOW();");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Reservation u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_RESERVATION = (int)reader.GetValue(6);
                    int ID_LIAISON = (int)reader.GetValue(7);
                    int ID_TRAVERSE = (int)reader.GetValue(8);
                    int ID_CLIENT = (int)reader.GetValue(9);
                    string Nomres = (string)reader.GetValue(10);

                    //Instanciation d'un Client
                    u = new Reservation(ID_RESERVATION, ID_LIAISON, ID_TRAVERSE, ID_CLIENT, Nomres);

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
        public static List<Reservation> getReservation()
        {

            List<Reservation> lc = new List<Reservation>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("Select * from reservation");

                // lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Reservation u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_RESERVATION = (int)reader.GetValue(0);
                    int ID_LIAISON = (int)reader.GetValue(1);
                    int ID_TRAVERSE = (int)reader.GetValue(2);
                    int ID_CLIENT = (int)reader.GetValue(3);
                    string Nomres = (string)reader.GetValue(4);

                    //Instanciation d'un Client
                    u = new Reservation(ID_RESERVATION, ID_LIAISON, ID_TRAVERSE, ID_CLIENT, Nomres);

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

