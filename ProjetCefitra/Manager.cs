using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ProjetCefitra
{
    class Manager
    {
        List<Client> clients;
        List<Fournisseur> fournisseurs;
        List<OperationClient> operationClients;
        List<OperationFournisseur> operationFournisseurs;

        internal List<Client> Clients { get => clients; set => clients = value; }
        internal List<Fournisseur> Fournisseurs { get => fournisseurs; set => fournisseurs = value; }
        internal List<OperationClient> OperationClients { get => operationClients; set => operationClients = value; }
        internal List<OperationFournisseur> OperationFournisseurs { get => operationFournisseurs; set => operationFournisseurs = value; }

        public Manager()
        {
            clients = new List<Client>();
            fournisseurs = new List<Fournisseur>();
            operationClients = new List<OperationClient>();
            operationFournisseurs = new List<OperationFournisseur>();
        }

        //Clients
        public void addClient(Client client)
        {
            clients.Add(client);
            app.mysdao.open();
            app.mysdao.insertIntoClient(client);
            app.mysdao.close();
        }

        public void deleteClient(string code)
        {
            app.mysdao.open();
            app.mysdao.deleteFromClient(searchByCode(code));
            app.mysdao.close();

            clients.Remove(searchByCode(code));
            
        }

        public void updateClient(Client client, Client newClient)
        {
            client.Code = newClient.Code;
            client.Nom = newClient.Nom;
            client.Tel = newClient.Tel;
            client.Adresse = newClient.Adresse;
            client.DateInscriptionClient = newClient.DateInscriptionClient;
        }

        public List<Client> searchClientByKey(string cle)
        {
            List<Client> list = new List<Client>();
            foreach(Client client in clients)
            {
                if (client.Nom.Contains(cle))
                {
                    list.Add(client);
                }

            }

            return list;
        }

        public Client searchByCode(string code)
        {
            foreach(Client client in clients)
            {
                if (client.Code == code)
                    return client;
            }
            return null;
        }


        //Fournisseurs

        public void addFournisseur(Fournisseur fournisseur)
        {
            fournisseurs.Add(fournisseur);
            app.mysdao.open();
            app.mysdao.insertIntoFournisseur(fournisseur);
            app.mysdao.close();
        }

        public void deleteFournisseur(String  code)
        {
            app.mysdao.open();
            app.mysdao.deleteFromFournisseur(searchFournisseurByCode(code));
            app.mysdao.close();

            fournisseurs.Remove(searchFournisseurByCode(code));
            
        }

        public void updateFournisseur(Fournisseur fournisseur, Fournisseur newFournisseur)
        {
            fournisseur.Code = newFournisseur.Code;
            fournisseur.Nom = newFournisseur.Nom;
            fournisseur.Tel = newFournisseur.Tel;
            fournisseur.Adresse = newFournisseur.Adresse;
            fournisseur.DateInscription = newFournisseur.DateInscription;
        }

        public Fournisseur searchFournisseurByCode(string code)
        {
            foreach (Fournisseur fournisseur in fournisseurs)
            {
                if (fournisseur.Code == code)
                    return fournisseur;
            }
            return null;
        }

        public List<Fournisseur> searchFournisseurByKey(string cle)
        {
            List<Fournisseur> list = new List<Fournisseur>();
            foreach (Fournisseur fournisseur in fournisseurs)
            {
                if (fournisseur.Nom.Contains(cle))
                {
                    list.Add(fournisseur);
                }

            }

            return list;
        }

        //operation clients

        public void addOperationClient(OperationClient operationClient)
        {
            operationClients.Add(operationClient);
            app.mysdao.open();
            app.mysdao.insertIntoOperationClient(operationClient);
            app.mysdao.close();
        }

        public List<OperationClient> searchOperationByClient(Client client)
        {
            List<OperationClient> list = new List<OperationClient>();

            foreach (OperationClient operation in operationClients)
            {
                if (operation.Client.Code == client.Code)
                {
                    list.Add(operation);
                }
            }

            return list;
        }

        public List<OperationClient> searchOperationByNomClient(string nomClient)
        {
            List<OperationClient> list = new List<OperationClient>();

            foreach (OperationClient operation in operationClients)
            {
                if (operation.Client.Nom.Contains(nomClient))
                {
                    list.Add(operation);
                }
            }

            return list;
        }

        public List<OperationClient> searchOperationByMonth(int mois, int year)
        {
            List<OperationClient> list = new List<OperationClient>();

            foreach (OperationClient operation in operationClients)
            {
                if (operation.DateOperation.Month == mois && operation.DateOperation.Year == year)
                {
                    list.Add(operation);
                }
            }

            return list;
        }

        public OperationClient searchOperationCLientByCode(string code)
        {

            foreach (OperationClient operation in operationClients)
            {
                if (operation.Code == code)
                {
                    return operation;
                }
            }

            return null;
        }

        public void updateOperationClient(OperationClient operation, OperationClient newOperation)
        {
            operation.Designation = newOperation.Designation;
            operation.Quantite = newOperation.Quantite;
            operation.PrixUnitaire = newOperation.PrixUnitaire;
            operation.Paiement.ModePaiement = newOperation.Paiement.ModePaiement;
            operation.Paiement.Montant = newOperation.Paiement.Montant;
            operation.Paiement.Regler = newOperation.Paiement.Regler;
            operation.Paiement.Reste = newOperation.Paiement.Reste;
        }

        public void deleteOperationClient(string code)
        {
            app.mysdao.open();
            app.mysdao.deleteFromOperationClient(searchOperationCLientByCode(code));
            app.mysdao.close();

            operationClients.Remove(searchOperationCLientByCode(code));
            
        }

        // operations Fournisseurs

        public void addOperationFournisseur(OperationFournisseur operationFournisseur)
        {
            operationFournisseurs.Add(operationFournisseur);
            app.mysdao.open();
            app.mysdao.insertIntoOperationFournisseur(operationFournisseur);
            app.mysdao.close();
        }

        public List<OperationFournisseur> searchOperationByFournisseur(Fournisseur fournisseur)
        {
            List<OperationFournisseur> list = new List<OperationFournisseur>();

            foreach (OperationFournisseur operation in operationFournisseurs)
            {
                if (operation.Fournisseur.Code == fournisseur.Code)
                {
                    list.Add(operation);
                }
            }

            return list;
        }

        public List<OperationFournisseur> searchOperationByNomFournisseur(string nomFournisseur)
        {
            List<OperationFournisseur> list = new List<OperationFournisseur>();

            foreach (OperationFournisseur operation in operationFournisseurs)
            {
                if (operation.Fournisseur.Nom.Contains(nomFournisseur))
                {
                    list.Add(operation);
                }
            }

            return list;
        }

        public List<OperationFournisseur> searchOperationFournisseurByMonth(int mois, int year)
        {
            List<OperationFournisseur> list = new List<OperationFournisseur>();

            foreach (OperationFournisseur operation in operationFournisseurs)
            {
                if (operation.DateOperation.Month == mois && operation.DateOperation.Year == year)
                {
                    list.Add(operation);
                }
            }

            return list;
        }

        public OperationFournisseur searchOperationFournisseurByCode(string code)
        {

            foreach (OperationFournisseur operation in operationFournisseurs)
            {
                if (operation.Code == code)
                {
                    return operation;
                }
            }

            return null;
        }

        public void updateOperationFournisseur(OperationFournisseur operation, OperationFournisseur newOperation)
        {
            operation.Designation = newOperation.Designation;
            operation.Quantite = newOperation.Quantite;
            operation.PrixUnitaire = newOperation.PrixUnitaire;
            operation.Paiement.ModePaiement = newOperation.Paiement.ModePaiement;
            operation.Paiement.Montant = newOperation.Paiement.Montant;
            operation.Paiement.Regler = newOperation.Paiement.Regler;
            operation.Paiement.Reste = newOperation.Paiement.Reste;
        }

        public void deleteOperationFournisseur(string code)
        {
            app.mysdao.open();
            app.mysdao.deleteFromOperationFournisseur(searchOperationFournisseurByCode(code));
            app.mysdao.close();

            operationFournisseurs.Remove(searchOperationFournisseurByCode(code));
            
        }

        //d'autrtes

        public void afficherClient()
        {
            foreach (Client client in clients)
            {
                Console.WriteLine(client);
            }
        }

        public void afficherOperationClient()
        {
            foreach (OperationClient operationClient in operationClients)
            {
                Console.WriteLine(operationClient);
            }
        }


        public void serialiserXML()
        {
            try
            {
                //serialiser Clients
                FileStream f = new FileStream("Clients.xml", FileMode.Create);
                XmlSerializer xml = new XmlSerializer(typeof(List<Client>)); 
                xml.Serialize(f, clients);
                f.Close();

                //serialiser Fournisseurs
                FileStream f2 = new FileStream("Fournisseurs.xml", FileMode.Create);
                XmlSerializer xml2 = new XmlSerializer(typeof(List<Fournisseur>));
                xml2.Serialize(f2, fournisseurs);
                f2.Close();

                //serialiser les operations clients
                FileStream f3 = new FileStream("OperationClients.xml", FileMode.Create);
                XmlSerializer xml3 = new XmlSerializer(typeof(List<OperationClient>));
                xml3.Serialize(f3, operationClients);
                f3.Close();

                //serialiser les operations Fournisseurs
                FileStream f4 = new FileStream("OperationFournisseurs.xml", FileMode.Create);
                XmlSerializer xml4 = new XmlSerializer(typeof(List<OperationFournisseur>));
                xml4.Serialize(f4, operationFournisseurs);
                f4.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("Erreur Serialization : " + e.Message);
            }

        }

        public void deserialiserXML()
        {
            try
            {
                //deserialiser Clients
                FileStream f = new FileStream("Clients.xml", FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(List<Client>));
                clients = (List<Client>)xml.Deserialize(f);
                f.Close();

                //deserialiser Fournisseurs
                FileStream f2 = new FileStream("Fournisseurs.xml", FileMode.Open);
                XmlSerializer xml2 = new XmlSerializer(typeof(List<Fournisseur>));
                fournisseurs = (List<Fournisseur>)xml2.Deserialize(f2);
                f2.Close();

                //deserialiser operations clients
                FileStream f3 = new FileStream("OperationClients.xml", FileMode.Open);
                XmlSerializer xml3 = new XmlSerializer(typeof(List<OperationClient>));
                operationClients = (List<OperationClient>)xml3.Deserialize(f3);
                f3.Close();

                //deserialiser les operations Fournisseurs
                FileStream f4 = new FileStream("OperationFournisseurs.xml", FileMode.Open);
                XmlSerializer xml4 = new XmlSerializer(typeof(List<OperationFournisseur>));
                operationFournisseurs = (List<OperationFournisseur>)xml4.Deserialize(f4);
                f4.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur Deserialisation : ", e.Message);
            }

        }

     }
}
