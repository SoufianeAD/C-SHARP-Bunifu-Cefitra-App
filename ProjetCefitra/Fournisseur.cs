using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCefitra
{
    [Serializable]

    public class Fournisseur
    {
        string code;
        string nom;
        string tel;
        string adresse;
        DateTime dateInscription;

        public string Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public DateTime DateInscription { get => dateInscription; set => dateInscription = value; }

        public Fournisseur()
        {

        }

        public Fournisseur(string code, string nom, string tel, string adresse, DateTime dateInscription)
        {
            this.code = code;
            this.nom = nom;
            this.tel = tel;
            this.adresse = adresse;
            this.dateInscription = dateInscription;
        }

        public override string ToString()
        {
            return code + "," + nom + "," + tel + "," + adresse + "," + dateInscription.ToShortDateString();
        }
    }
}
