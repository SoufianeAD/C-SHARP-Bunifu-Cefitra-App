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
    public partial class ClientForm : Form
    {
        string code = "";


        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            loadData(app.manager.Clients);
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            AddForm form = new AddForm();
            form.ShowDialog();
            Show();
            loadData(app.manager.Clients);
            
        }

        private void loadData(List<Client> clients)
        {
            //load liste clients
            
            bunifuCustomDataGrid1.Rows.Clear();

            foreach (Client client in clients)
            {
                bunifuCustomDataGrid1.Rows.Add(client.Code, client.Nom, client.Tel, client.Adresse);
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer ce Client", "",  MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult d = MessageBox.Show("Voulez vous supprimer les factures de ce client?", "", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        try
                        {                           
                            string nom = app.manager.searchByCode(code).Nom;
                            Directory.Delete(app.wd + "FacturesClients/" + nom, true);
                        }
                        catch (Exception)
                        {

                        }
                    }

                    app.manager.deleteClient(code);
                    
                    code = "";
                    loadData(app.manager.Clients);
                }
                else loadData(app.manager.Clients);
            }
            else MessageBox.Show("Il faut choisir un Client");

        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {
            loadData(app.manager.searchClientByKey(bunifuCustomTextbox1.Text));
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                Client client = app.manager.searchByCode(code);
                Hide();
                ModifyForm form = new ModifyForm(client);
                form.ShowDialog();
                Show();
                loadData(app.manager.Clients);
            }
            else MessageBox.Show("Il faut choisir un Client");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Client client = app.manager.searchByCode(code);
            if (client != null)
            {
                Hide();
                InfoClient form = new InfoClient(client);
                form.ShowDialog();
                Show();
                loadData(app.manager.Clients);
            }
            else MessageBox.Show("Il faut choisir un Client");
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                code = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuCustomTextbox2.Text = code + " --- " + bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Console.WriteLine(code);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
