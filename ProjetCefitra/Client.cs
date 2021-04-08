using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCefitra
{
    [Serializable]

    public class Client
    {
        string code;//cin ou ice
        string nom;//nom client ou la societe
        string tel;
        string adresse;
        DateTime dateInscriptionClient;

        public string Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public DateTime DateInscriptionClient { get => dateInscriptionClient; set => dateInscriptionClient = value; }

        public Client(string code, string nom, string tel, string adresse, DateTime dateInscriptionClient)
        {
            this.code = code;
            this.nom = nom;
            this.tel = tel;
            this.adresse = adresse;
            this.dateInscriptionClient = dateInscriptionClient;
        }

        public Client()
        {
        }

        public override string ToString()
        {
            return code + "," + nom + "," + tel + "," + adresse + "," + dateInscriptionClient.ToShortDateString();
        }
    }
}
