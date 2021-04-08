using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCefitra
{
    [Serializable]

    public class OperationClient
    {
        string code;
        Client client;
        Paiement paiement;
        string designation;
        double quantite;
        double prixUnitaire;
        DateTime dateOperation;


        public string Code { get => code; set => code = value; }
        public string Designation { get => designation; set => designation = value; }
        public double Quantite { get => quantite; set => quantite = value; }
        public double PrixUnitaire { get => prixUnitaire; set => prixUnitaire = value; }
        public  Client Client { get => client; set => client = value; }
        public  Paiement Paiement { get => paiement; set => paiement = value; }
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }

        public OperationClient()
        {
        }

        public OperationClient(string code, Client client, Paiement paiement, string designation, double quantite, double prixUnitaire, DateTime dateOperation)
        {
            this.code = code;
            this.client = client;
            this.paiement = paiement;
            this.designation = designation;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.dateOperation = dateOperation;
        }

        public override string ToString()
        {
            return code + "," + designation + "," + quantite + "," + prixUnitaire + "," + client.ToString() + paiement.ToString() + "," 
                + dateOperation.ToShortDateString();
        }

    }
}
