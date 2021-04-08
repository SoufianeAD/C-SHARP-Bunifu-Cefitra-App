using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;



namespace ProjetCefitra
{
    class DAO
    {
        MySqlConnection connection = new MySqlConnection();
        MySqlCommand commande = new MySqlCommand();

        public DAO()
        {
           
        }

        public void open()
        {
            connection.ConnectionString = "Server=localhost;Database=projettutore;UID=root";
            connection.Open();
            commande.Connection = connection;
        }

        public void close()
        {
            connection.Close();
        }

        //INSERT

        public void insertIntoClient(Client client)
        {         
                try
                {
                    string req = "INSERT INTO Client VALUES('" + client.Code + "','" + client.Nom + "','" + client.Tel + "','" + client.Adresse + "','" +
                               client.DateInscriptionClient.Year + "-" + client.DateInscriptionClient.Month + "-" + client.DateInscriptionClient.Day + "')";
                    commande.CommandText = req;
                    commande.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "insert into client");
                }
            
        }

        public void insertIntoFournisseur(Fournisseur fournisseur)
        {
            
                try
                {
                    string req = "INSERT INTO Fournisseur VALUES('" + fournisseur.Code + "','" + fournisseur.Nom + "','" + fournisseur.Tel + "','" + fournisseur.Adresse + "','" +
                                           fournisseur.DateInscription.Year + "-" + fournisseur.DateInscription.Month + "-" + fournisseur.DateInscription.Day + "')";
                    commande.CommandText = req;
                    commande.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "insert into  fournisseur");
                }
            
        }

        public void insertIntoOperationClient(OperationClient op)
        {
            
                try
                {
                    string req = "insert into operationclient values('" + op.Code + "','" + op.Client.Code + "','" + op.Paiement.ModePaiement + "','" + op.Paiement.Montant
                        + "','" + op.Paiement.Regler + "','" + op.Paiement.Reste + "','" + op.Designation + "','" + op.Quantite + "','" + op.PrixUnitaire + "','"
                                           + op.DateOperation.Year + "-" + op.DateOperation.Month + "-" + op.DateOperation.Day + "')";

                    commande.CommandText = req;
                    commande.ExecuteNonQuery();
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "insert into ope client");
                }
            
        }

        public void insertIntoOperationFournisseur(OperationFournisseur op)
        {
           
                try
                {
                    string req = "insert into operationFournisseur values('" + op.Code + "','" + op.Fournisseur.Code + "','" + op.Paiement.ModePaiement + "','" + op.Paiement.Montant
                        + "','" + op.Paiement.Regler + "','" + op.Paiement.Reste + "','" + op.Designation + "','" + op.Quantite + "','" + op.PrixUnitaire + "','"
                                           + op.DateOperation.Year + "-" + op.DateOperation.Month + "-" + op.DateOperation.Day + "')";

                    commande.CommandText = req;
                    commande.ExecuteNonQuery();
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
        }
        //update

        //delete

        public void deleteFromClient(Client client)
        {
            try
            {
                string req = "DELETE FROM client WHERE codeClient like '" + client.Code + "';";
                commande.CommandText = req;
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "delete into client");
            }

        }

        public void deleteFromFournisseur(Fournisseur fournisseur)
        {

            try
            {
                string req = "DELETE FROM fournisseur WHERE codefournisseur like '" + fournisseur.Code + "';";
                commande.CommandText = req;
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "delete into  fournisseur");
            }

        }

        public void deleteFromOperationClient(OperationClient op)
        {

            try
            {
                string req = "DELETE FROM operationclient WHERE codeoperationclient like '" + op.Code + "';";

                commande.CommandText = req;
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "delete into ope client");
            }

        }

        public void deleteFromOperationFournisseur(OperationFournisseur op)
        {

            try
            {
                string req = "DELETE FROM operationFournisseur WHERE codeoperationfournisseur like '" + op.Code + "';";

                commande.CommandText = req;
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //clear

        public void clearDB()
        {
            try
            {
                string req = "DELETE FROM OPERATIONCLIENT;";
                commande.CommandText = req;
                commande.ExecuteNonQuery();

                req = "DELETE FROM OPERATIONFOURNISSEUR;";
                commande.CommandText = req;
                commande.ExecuteNonQuery();

                req = "DELETE FROM CLIENT;";
                commande.CommandText = req;
                commande.ExecuteNonQuery();

                req = "DELETE FROM FOURNISSEUR;";
                commande.CommandText = req;
                commande.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}

