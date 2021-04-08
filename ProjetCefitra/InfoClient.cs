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
    public partial class InfoClient : Form
    {
        Client client;

        public InfoClient(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void InfoClient_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = client.Code;
            bunifuCustomTextbox2.Text = client.Nom;
            bunifuCustomTextbox3.Text = client.Tel;
            bunifuCustomTextbox4.Text = client.Adresse;
            bunifuDatepicker1.Value = client.DateInscriptionClient;

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
            List<OperationClient> list = app.manager.searchOperationByClient(client);

            foreach (OperationClient operation in list)
            {
                bunifuCustomDataGrid1.Rows.Add(operation.Code, operation.Designation, operation.Quantite, operation.Paiement.Montant, 
                    operation.DateOperation.ToShortDateString());
            }
        }
    }
}
