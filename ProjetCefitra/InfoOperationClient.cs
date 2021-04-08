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
    public partial class InfoOperationClient : Form
    {
        OperationClient operation;

        public InfoOperationClient(OperationClient operation)
        {
            InitializeComponent();
            this.operation = operation;
        }

        private void InfoOperationClient_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = operation.Code;
            bunifuCustomTextbox8.Text = operation.Client.Nom;
            bunifuCustomTextbox2.Text = operation.Designation;
            bunifuCustomTextbox3.Text = operation.Quantite + "";
            bunifuCustomTextbox4.Text = operation.PrixUnitaire + "";
            bunifuDatepicker1.Value = operation.DateOperation;
            bunifuCustomTextbox9.Text = operation.Paiement.ModePaiement;
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
            try
            {
                string destination = app.wd + "FacturesClients/" + operation.Client.Nom + "/" + operation.Code + ".xlsx";
                System.Diagnostics.Process.Start(destination);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cette facture est introuvable.");
            }
        }
    }
}
