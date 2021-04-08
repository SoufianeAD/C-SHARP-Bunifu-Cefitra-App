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
    public partial class OperationCLientForm : Form
    {
        string code = "";

        public OperationCLientForm()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            AddOperationClient form = new AddOperationClient();
            form.ShowDialog();
            Show();
            loadData(app.manager.OperationClients);
           
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadData(List<OperationClient> operationClients)
        {
            //load liste clients

            bunifuCustomDataGrid1.Rows.Clear();

            foreach (OperationClient operationClient in operationClients)
            {
                bunifuCustomDataGrid1.Rows.Add(operationClient.Code, operationClient.Client.Nom, operationClient.Designation,
                    operationClient.Quantite, operationClient.Paiement.Montant, operationClient.DateOperation.ToShortDateString());
            }
        }

        private void OperationCLientForm_Load(object sender, EventArgs e)
        {
            loadData(app.manager.OperationClients);
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

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {
            loadData(app.manager.searchOperationByNomClient(bunifuCustomTextbox1.Text));
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            loadData(app.manager.searchOperationByMonth(bunifuDatepicker1.Value.Month, bunifuDatepicker1.Value.Year));
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if(code != "")
            {
                Hide();
                ModifyOperationClient form = new ModifyOperationClient(app.manager.searchOperationCLientByCode(code));
                form.ShowDialog();
                Show();
                loadData(app.manager.OperationClients);
            }
            else MessageBox.Show("Il faut choisir une Operation");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            loadData(app.manager.OperationClients);
            bunifuCustomTextbox1.Text = "";
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                Hide();
                InfoOperationClient form = new InfoOperationClient(app.manager.searchOperationCLientByCode(code));
                form.ShowDialog();
                Show();
                loadData(app.manager.OperationClients);
            }
            else MessageBox.Show("Il faut choisir une Operation");
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer cette Operation", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    app.manager.deleteOperationClient(code);
                    code = "";
                    loadData(app.manager.OperationClients);
                }
                else loadData(app.manager.OperationClients);
            }
            else MessageBox.Show("Il faut choisir une Operation");
        }
    }
}
