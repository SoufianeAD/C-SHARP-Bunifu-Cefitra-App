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
    public partial class ModifyOperationFournisseur : Form
    {
        OperationFournisseur operation;

        public ModifyOperationFournisseur(OperationFournisseur operation)
        {
            InitializeComponent();
            this.operation = operation;
        }

        private void ModifyOperationFournisseur_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = operation.Code;
            bunifuCustomTextbox8.Text = operation.Fournisseur.Nom;
            bunifuCustomTextbox2.Text = operation.Designation;
            bunifuCustomTextbox3.Text = operation.Quantite + "";
            bunifuCustomTextbox4.Text = operation.PrixUnitaire + "";
            bunifuDatepicker1.Value = operation.DateOperation;
            metroComboBox2.Items.Add("Espèce");
            metroComboBox2.Items.Add("Chèque");
            metroComboBox2.Items.Add("Effet");
            if (operation.Paiement.ModePaiement == "Espèce")
                metroComboBox2.SelectedIndex = 0;
            else if (operation.Paiement.ModePaiement == "Chèque")
                metroComboBox2.SelectedIndex = 1;
            else
                metroComboBox2.SelectedIndex = 2;
            bunifuCustomTextbox5.Text = operation.Paiement.Montant + "";
            bunifuCustomTextbox6.Text = operation.Paiement.Regler + "";
            bunifuCustomTextbox7.Text = operation.Paiement.Reste + "";

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string code = bunifuCustomTextbox1.Text;
            Fournisseur fournisseur = app.manager.searchFournisseurByKey(bunifuCustomTextbox8.Text)[0];


            string modePaiement = (string)metroComboBox2.SelectedItem;
            double montant = Double.Parse(bunifuCustomTextbox5.Text);
            double regle = Double.Parse(bunifuCustomTextbox6.Text);
            double reste = Double.Parse(bunifuCustomTextbox7.Text);

            Paiement paiement = new Paiement(modePaiement, montant, regle, reste);

            string designation = bunifuCustomTextbox2.Text;
            double quantite = Double.Parse(bunifuCustomTextbox3.Text);
            double prixUnitaire = Double.Parse(bunifuCustomTextbox4.Text);
            DateTime dateOperation = bunifuDatepicker1.Value;

            app.manager.updateOperationFournisseur(operation, new OperationFournisseur(code, fournisseur, paiement, designation, quantite, prixUnitaire, dateOperation));
            Close();
        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomTextbox5.Text = (Double.Parse(bunifuCustomTextbox3.Text) * Double.Parse(bunifuCustomTextbox4.Text)) + "";
                bunifuCustomTextbox6.Text = bunifuCustomTextbox5.Text;
                bunifuCustomTextbox7.Text = 0 + "";
            }
            catch (Exception)
            {
            }
        }

        private void bunifuCustomTextbox4_Validated(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomTextbox5.Text = (Double.Parse(bunifuCustomTextbox3.Text) * Double.Parse(bunifuCustomTextbox4.Text)) + "";
                bunifuCustomTextbox6.Text = bunifuCustomTextbox5.Text;
                bunifuCustomTextbox7.Text = 0 + "";
            }
            catch (Exception)
            {
            }
        }
    }
}
