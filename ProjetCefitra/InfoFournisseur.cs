using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetCefitra
{
    public partial class InfoFournisseur : Form
    {
        Fournisseur fournisseur;

        public InfoFournisseur(Fournisseur fournisseur)
        {
            InitializeComponent();
            this.fournisseur = fournisseur;
        }

        private void InfoFournisseur_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = fournisseur.Code;
            bunifuCustomTextbox2.Text = fournisseur.Nom;
            bunifuCustomTextbox3.Text = fournisseur.Tel;
            bunifuCustomTextbox4.Text = fournisseur.Adresse;
            bunifuDatepicker1.Value = fournisseur.DateInscription;
            loadData();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadData()
        {
            bunifuCustomDataGrid1.Rows.Clear();
            List<OperationFournisseur> list = app.manager.searchOperationByFournisseur(fournisseur);

            foreach (OperationFournisseur operation in list)
            {
                bunifuCustomDataGrid1.Rows.Add(operation.Code, operation.Designation, operation.Quantite, operation.Paiement.Montant,
                    operation.DateOperation.ToShortDateString());
            }
        }
    }
}
