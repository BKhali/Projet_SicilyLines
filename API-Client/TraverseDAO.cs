using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace API_Client
{
    public class TraverseDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "slines";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        public static List<Traverse> getTraverse()
        {

            List<Traverse> lc = new List<Traverse>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("Select * from traverse");

                // lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Traverse u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_LIAISON = (int)reader.GetValue(0);
                    int ID_TRAVERSE = (int)reader.GetValue(1);
                    string NOM = (string)reader.GetValue(3);
                    DateTime DATETRAVERSE = (DateTime)reader.GetValue(4);

                    //Instanciation d'un Client
                    u = new Traverse(ID_LIAISON, ID_TRAVERSE, NOM, DATETRAVERSE);

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

        public static List<Traverse> getTraversecli(int cli)
        {

            List<Traverse> lc = new List<Traverse>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("SELECT t.ID_LIAISON, t.ID_TRAVERSE, t.NOM, t.DATETRAVERSE, t.HEURE, b.NOM AS NOM_BATEAU, p1.NOM AS PORT_DEPART, p2.NOM AS PORT_ARRIVEE FROM traverse t JOIN reservation r ON t.ID_LIAISON = r.ID_LIAISON AND t.ID_TRAVERSE = r.ID_TRAVERSE JOIN client c ON r.ID_CLIENT = c.ID_CLIENT JOIN bateau b ON t.ID_BATEAU = b.ID_BATEAU JOIN liaison l ON t.ID_LIAISON = l.ID_LIAISON JOIN port p1 ON l.id_port_depart = p1.ID_PORT JOIN port p2 ON l.id_port_arrivee = p2.ID_PORT WHERE c.ID_CLIENT =" + cli + ";");

                // lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Traverse u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_LIAISON = (int)reader.GetValue(0);
                    int ID_TRAVERSE = (int)reader.GetValue(1);
                    string NOM = (string)reader.GetValue(2);
                    DateTime DATETRAVERSE = (DateTime)reader.GetValue(3);
                    //Instanciation d'un Client
                    u = new Traverse(ID_LIAISON, ID_TRAVERSE, NOM, DATETRAVERSE);

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
        public static List<Traverse> getTraversefutur(int cli)
        {

            List<Traverse> lc = new List<Traverse>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("SELECT * FROM traverse t JOIN reservation r ON t.ID_LIAISON = r.ID_LIAISON AND t.ID_TRAVERSE = r.ID_TRAVERSE WHERE r.ID_CLIENT = " + cli + " AND CONCAT(t.DATETRAVERSE, ' ', t.HEURE) > NOW();");

                // lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Traverse u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_LIAISON = (int)reader.GetValue(0);
                    int ID_TRAVERSE = (int)reader.GetValue(1);
                    string NOM = (string)reader.GetValue(3);
                    DateTime DATETRAVERSE = (DateTime)reader.GetValue(4);

                    //Instanciation d'un Client
                    u = new Traverse(ID_LIAISON, ID_TRAVERSE, NOM, DATETRAVERSE);

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

        public static List<Traverse> getTraversepasse(int cli)
        {

            List<Traverse> lc = new List<Traverse>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("SELECT * FROM traverse t JOIN reservation r ON t.ID_LIAISON = r.ID_LIAISON AND t.ID_TRAVERSE = r.ID_TRAVERSE WHERE r.ID_CLIENT = " + cli + " AND CONCAT(t.DATETRAVERSE, ' ', t.HEURE) < NOW();");

                // lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Traverse u;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int ID_LIAISON = (int)reader.GetValue(0);
                    int ID_TRAVERSE = (int)reader.GetValue(1);
                    string NOM = (string)reader.GetValue(3);
                    DateTime DATETRAVERSE = (DateTime)reader.GetValue(4);

                    //Instanciation d'un Client
                    u = new Traverse(ID_LIAISON, ID_TRAVERSE, NOM, DATETRAVERSE);

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

