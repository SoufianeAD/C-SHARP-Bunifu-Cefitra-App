using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCefitra
{
    [Serializable]

    public class Paiement
    {
        string modePaiement;
        double montant;
        double regler;
        double reste;

        public string ModePaiement { get => modePaiement; set => modePaiement = value; }
        public double Montant { get => montant; set => montant = value; }
        public double Regler { get => regler; set => regler = value; }
        public double Reste { get => reste; set => reste = value; }


        public Paiement(string modePaiement, double montant, double regler, double reste)
        {
            this.modePaiement = modePaiement;
            this.montant = montant;
            this.regler = regler;
            this.reste = reste;
        }

        public Paiement()
        {
        }

        public override string ToString()
        {
            return modePaiement + "," + montant + "," + regler + "," + reste;
        }
    }
}
