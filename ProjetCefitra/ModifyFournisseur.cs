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
    public partial class ModifyFournisseur : Form
    {
        Fournisseur fournisseur;

        public ModifyFournisseur(Fournisseur fournisseur)
        {
            InitializeComponent();
            this.fournisseur = fournisseur;
        }

        private void ModifyFournisseur_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = fournisseur.Code;
            bunifuCustomTextbox2.Text = fournisseur.Nom;
            bunifuCustomTextbox3.Text = fournisseur.Tel;
            bunifuCustomTextbox4.Text = fournisseur.Adresse;
            bunifuDatepicker1.Value = fournisseur.DateInscription;

            bunifuCustomTextbox1.Enabled = false;
            bunifuCustomTextbox2.Enabled = false;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox1.Text == "" || bunifuCustomTextbox2.Text == "")
            {
                MessageBox.Show("Le code et le Nom sont obligatoire");
            }

            else
            {
                string code = bunifuCustomTextbox1.Text;
                string nom = bunifuCustomTextbox2.Text;
                string tel = bunifuCustomTextbox3.Text;
                string adresse = bunifuCustomTextbox4.Text;
                DateTime dateInscription = (DateTime)bunifuDatepicker1.Value;
                app.manager.updateFournisseur(fournisseur, new Fournisseur(code, nom, tel, adresse, dateInscription));
                Close();
            }
        }
    }
}
