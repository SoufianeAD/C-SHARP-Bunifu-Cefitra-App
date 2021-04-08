using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;


namespace ProjetCefitra
{
    class DAODB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ETUDES SUPERIEURE\Projets\2019\Projet tutoriel\appDesktop\ProjetCefitra\ProjetCefitra\db\Cefitra.mdf;Integrated Security=True";
        SqlConnection con;

        public DAODB()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open )
                MessageBox.Show("Connexion bien etablit");
            else
            {
                MessageBox.Show("Connexion echouée");
            }
        }

        public void close()
        {
            con.Close();
        }
        //INSERT

        public void insertIntoClient(List<Client> clients)
        {
            foreach (Client client in clients)
            {
                try
                {
                    string req = "INSERT INTO Client VALUES('" + client.Code + "','" + client.Nom + "','" + client.Tel + "','" + client.Adresse + "','" +
                               client.DateInscriptionClient.Year + "-" + client.DateInscriptionClient.Month + "-" + client.DateInscriptionClient.Day + "')";
                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "insert into client");
                } 
            }
        }

        public void insertIntoFournisseur(List<Fournisseur> fournisseurs)
        {
            foreach(Fournisseur fournisseur in fournisseurs)
            {
                try
                {
                    string req = "INSERT INTO Fournisseur VALUES('" + fournisseur.Code + "','" + fournisseur.Nom + "','" + fournisseur.Tel + "','" + fournisseur.Adresse + "','" +
                                           fournisseur.DateInscription.Year + "-" + fournisseur.DateInscription.Month + "-" + fournisseur.DateInscription.Day + "')";
                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "insert into  fournisseur");
                }
            }
        }

        public void insertIntoOperationClient(List<OperationClient> operationClients)
        {
            foreach (OperationClient op in operationClients)
            {
                try
                {
                    string req = "insert into operationclient values('" + op.Code + "','" + op.Client.Code + "','" + op.Paiement.ModePaiement + "','" + op.Paiement.Montant 
                        + "','" + op.Paiement.Regler + "','" + op.Paiement.Reste + "','" + op.Designation + "','" + op.Quantite + "','" + op.PrixUnitaire + "','"
                                           + op.DateOperation.Year + "-" + op.DateOperation.Month + "-" + op.DateOperation.Day + "')";

                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "insert into ope client");
                }
            }
        }

        public void insertIntoOperationFournisseur(List<OperationFournisseur> operationFournisseurs)
        {
            foreach (OperationFournisseur op in operationFournisseurs)
            {
                try
                {
                    string req = "insert into operationFournisseur values('" + op.Code + "','" + op.Fournisseur.Code + "','" + op.Paiement.ModePaiement + "','" + op.Paiement.Montant
                        + "','" + op.Paiement.Regler + "','" + op.Paiement.Reste + "','" + op.Designation + "','" + op.Quantite + "','" + op.PrixUnitaire + "','"
                                           + op.DateOperation.Year + "-" + op.DateOperation.Month + "-" + op.DateOperation.Day + "')";

                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //SELECT

        public void selectFromClient()
        {
            string req = "SELECT * FROM CLIENT;";
            SqlCommand cmd = new SqlCommand(req, con);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                string code = (string)r[0];
                string nom = (string)r[1];
                string tel = (string)r[2];
                string adresse = (string)r[3];
                DateTime dateInscription = (DateTime)r[4];
                Console.WriteLine(code + "," + nom + "," + tel + "," + adresse + "," + dateInscription.ToShortDateString());
                app.manager.addClient(new Client(code, nom, tel, adresse, dateInscription));
            }
            r.Close();
        }

        public void selectFromFournisseur()
        {
            string req = "SELECT * FROM FOURNISSEUR;";
            SqlCommand cmd = new SqlCommand(req, con);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                string code = (string)r[0];
                string nom = (string)r[1];
                string tel = (string)r[2];
                string adresse = (string)r[3];
                DateTime dateInscription = (DateTime)r[4];
                Console.WriteLine(code + "," + nom + "," + tel + "," + adresse + "," + dateInscription.ToShortDateString());
                app.manager.addFournisseur(new Fournisseur(code, nom, tel, adresse, dateInscription));
            }
            r.Close();
        }

        public void selectFromOperationClient()
        {
            string req = "SELECT * FROM OPERATIONCLIENT;";
            SqlCommand cmd = new SqlCommand(req, con);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                try
                {
                    string code = (string)r[0];
                    Client client = app.manager.searchByCode((string)r[1]);


                    string modePaiement = (string)r[2];
                    double montant = (double)r[3];
                    double regle = (double)r[4];
                    double reste = (double)r[5];



                    string designation = (string)r[6];
                    double quantite = (double)r[7];
                    double prixUnitaire = (double)r[8];
                    DateTime dateOperation = (DateTime)r[9];

                    Paiement paiement = new Paiement(modePaiement, montant, regle, reste);
                    Console.WriteLine(code + "," + client + "," + modePaiement + "," + montant + "," + regle + "," + reste + "," + designation + "," + quantite
                        + "," + prixUnitaire + "," + dateOperation);
                    app.manager.addOperationClient(new OperationClient(code, client, paiement, designation, quantite, prixUnitaire, dateOperation));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            r.Close();
        }

        public void selectFromOperationFournisseur()
        {
            string req = "SELECT * FROM OPERATIONFOURNISSEUR;";
            SqlCommand cmd = new SqlCommand(req, con);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                try
                {
                    string code = (string)r[0]; 
                    Fournisseur fournisseur = app.manager.searchFournisseurByCode((string)r[1]);


                    string modePaiement = (string)r[2];
                    double montant = (double)r[3];
                    double regle = (double)r[4];
                    double reste = (double)r[5];



                    string designation = (string)r[6];
                    double quantite = (double)r[7];
                    double prixUnitaire = (double)r[8];
                    DateTime dateOperation = (DateTime)r[9];

                    Paiement paiement = new Paiement(modePaiement, montant, regle, reste);
                    Console.WriteLine(code + "," + fournisseur + "," + modePaiement + "," + montant + "," + regle + "," + reste + "," + designation + "," + quantite
                        + "," + prixUnitaire + "," + dateOperation);
                    app.manager.addOperationFournisseur (new OperationFournisseur(code, fournisseur, paiement, designation, quantite, prixUnitaire, dateOperation));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            r.Close();
        }

        //DELETE
        public void clearDB()
        {
            try
            {
                string req = "DELETE FROM OPERATIONCLIENT;";
                SqlCommand cmd3 = new SqlCommand(req, con);
                cmd3.ExecuteNonQuery();

                req = "DELETE FROM OPERATIONFOURNISSEUR;";
                SqlCommand cmd4 = new SqlCommand(req, con);
                cmd4.ExecuteNonQuery();

                req = "DELETE FROM CLIENT;";
                SqlCommand cmd = new SqlCommand(req, con);
                cmd.ExecuteNonQuery();

                req = "DELETE FROM FOURNISSEUR;";
                SqlCommand cmd2 = new SqlCommand(req, con);
                cmd2.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
