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
    public partial class OperationFournisseurForm : Form
    {
        string code="";

        public OperationFournisseurForm()
        {
            InitializeComponent();
        }

        private void OperationFournisseurForm_Load(object sender, EventArgs e)
        {
            loadData(app.manager.OperationFournisseurs);
        }

        private void loadData(List<OperationFournisseur> operationFournisseurs)
        {
            //load liste fournisseurs

            bunifuCustomDataGrid1.Rows.Clear();

            foreach (OperationFournisseur operationFournisseur in operationFournisseurs)
            {
                bunifuCustomDataGrid1.Rows.Add(operationFournisseur.Code, operationFournisseur.Fournisseur.Nom, operationFournisseur.Designation,
                    operationFournisseur.Quantite, operationFournisseur.Paiement.Montant, operationFournisseur.DateOperation.ToShortDateString());
            }
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {
            loadData(app.manager.searchOperationByNomFournisseur(bunifuCustomTextbox1.Text));
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            loadData(app.manager.searchOperationFournisseurByMonth(bunifuDatepicker1.Value.Month, bunifuDatepicker1.Value.Year));
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            AddOperationFournisseur form = new AddOperationFournisseur();
            form.ShowDialog();
            Show();
            loadData(app.manager.OperationFournisseurs);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                Hide();
                ModifyOperationFournisseur form = new ModifyOperationFournisseur(app.manager.searchOperationFournisseurByCode(code));
                form.ShowDialog();
                Show();
                loadData(app.manager.OperationFournisseurs);
            }
            else MessageBox.Show("Il faut choisir une Operation");
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                Hide();
                InfoOperationFournisseur form = new InfoOperationFournisseur(app.manager.searchOperationFournisseurByCode(code));
                form.ShowDialog();
                Show();
                loadData(app.manager.OperationFournisseurs);
            }
            else MessageBox.Show("Il faut choisir une Operation");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            loadData(app.manager.OperationFournisseurs);
            bunifuCustomTextbox1.Text = "";
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer cette Operation", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    app.manager.deleteOperationFournisseur(code);
                    code = "";
                    loadData(app.manager.OperationFournisseurs);
                }
                else loadData(app.manager.OperationFournisseurs);
            }
            else MessageBox.Show("Il faut choisir une Operation");
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
