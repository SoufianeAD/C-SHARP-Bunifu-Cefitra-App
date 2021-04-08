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
    public partial class FournisseurForm : Form
    {
        string code="";

        public FournisseurForm()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FournisseurForm_Load(object sender, EventArgs e)
        {
            loadData(app.manager.Fournisseurs);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loadData(List<Fournisseur> fournisseurs)
        {
            //load liste fournisseurs

            bunifuCustomDataGrid1.Rows.Clear();

            foreach (Fournisseur fournisseur in fournisseurs)
            {
                bunifuCustomDataGrid1.Rows.Add(fournisseur.Code, fournisseur.Nom, fournisseur.Tel, fournisseur.Adresse);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            addFournisseur form = new addFournisseur();
            form.ShowDialog();
            Show();
            loadData(app.manager.Fournisseurs);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer ce Fournisseur", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult d = MessageBox.Show("Voulez vous supprimer les factures de ce Fournisseur?", "", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        try
                        {
                            string nom = app.manager.searchFournisseurByCode(code).Nom;
                            Directory.Delete(app.wd + "FacturesFournisseurs/" + nom, true);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    app.manager.deleteFournisseur(code);
                    loadData(app.manager.Fournisseurs);
                    code = "";
                }
                else loadData(app.manager.Fournisseurs);
            }
            else MessageBox.Show("Il faut choisir un Fournisseur");
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {
            loadData(app.manager.searchFournisseurByKey(bunifuCustomTextbox1.Text));
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                Fournisseur fournisseur = app.manager.searchFournisseurByCode(code);
                Hide();
                ModifyFournisseur form = new ModifyFournisseur(fournisseur);
                form.ShowDialog();
                Show();
                loadData(app.manager.Fournisseurs);
            }
            else MessageBox.Show("Il faut choisir un Fournisseur");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Fournisseur fournisseur = app.manager.searchFournisseurByCode(code);
            if (fournisseur != null)
            {
                Hide();
                InfoFournisseur form = new InfoFournisseur(fournisseur);
                form.ShowDialog();
                Show();
                loadData(app.manager.Fournisseurs);
            }
            else MessageBox.Show("Il faut choisir un Fournisseur");
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
    }
}
