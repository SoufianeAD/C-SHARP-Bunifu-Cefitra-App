using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjetCefitra
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
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
                if(app.manager.searchClientByKey(bunifuCustomTextbox2.Text).Count == 0 && app.manager.searchByCode(bunifuCustomTextbox1.Text) == null)
                {
                    string code = bunifuCustomTextbox1.Text;
                    string nom = bunifuCustomTextbox2.Text;
                    string tel = bunifuCustomTextbox3.Text;
                    string adresse = bunifuCustomTextbox4.Text;
                    DateTime dateInscription = (DateTime)bunifuDatepicker1.Value;
                    app.manager.addClient(new Client(code, nom, tel, adresse, dateInscription));
                    //creer repertoire                 
                    Directory.CreateDirectory(app.wd + "FacturesClients/"  + nom);

                    Close();
                }
                else MessageBox.Show("Ce Client existe déja");


            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            bunifuDatepicker1.Value = DateTime.Now;
        }
    }
}
