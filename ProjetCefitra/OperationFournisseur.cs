using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCefitra
{
    [Serializable]
    public class OperationFournisseur
    {
        string code;
        Fournisseur fournisseur;
        Paiement paiement;
        string designation;
        double quantite;
        double prixUnitaire;
        DateTime dateOperation;

        public string Code { get => code; set => code = value; }
        public string Designation { get => designation; set => designation = value; }
        public double Quantite { get => quantite; set => quantite = value; }
        public double PrixUnitaire { get => prixUnitaire; set => prixUnitaire = value; }
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }
        public Fournisseur Fournisseur { get => fournisseur; set => fournisseur = value; }
        public Paiement Paiement { get => paiement; set => paiement = value; }

        public OperationFournisseur(string code, Fournisseur fournisseur, Paiement paiement, string designation, double quantite, double prixUnitaire, DateTime dateOperation)
        {
            this.code = code;
            this.fournisseur = fournisseur;
            this.paiement = paiement;
            this.designation = designation;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.dateOperation = dateOperation;
        }

        public OperationFournisseur()
        {
        }

        public override string ToString()
        {
            return Code + "," + Fournisseur + "," + paiement + "," + Designation + "," + Quantite + "," + prixUnitaire + "," + DateOperation.ToShortDateString();
        }
    }
}
