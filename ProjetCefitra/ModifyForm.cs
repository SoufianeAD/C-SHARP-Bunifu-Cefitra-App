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
    public partial class ModifyForm : Form
    {
        Client client;

        public ModifyForm(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = client.Code;
            bunifuCustomTextbox2.Text = client.Nom;
            bunifuCustomTextbox3.Text = client.Tel;
            bunifuCustomTextbox4.Text = client.Adresse;
            bunifuDatepicker1.Value = client.DateInscriptionClient;

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
                    app.manager.updateClient(client, new Client(code, nom, tel, adresse, dateInscription));
                    Close();
            }
        }
    }
}
