using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using System.IO;

namespace ProjetCefitra
{
    public partial class AddOperationClient : Form
    {
        double horsTaxe;
        double tva;
        double ttc;

        public AddOperationClient()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox1.Text == "" )
            {
                MessageBox.Show("Le code est obligatoire");
            }
            else
            {
                if(app.manager.searchOperationCLientByCode(bunifuCustomTextbox1.Text) == null)
                {
                    string code = bunifuCustomTextbox1.Text;
                    Client client = app.manager.searchClientByKey((string)metroComboBox1.SelectedItem)[0];


                    string modePaiement = (string)metroComboBox2.SelectedItem;
                    double montant = Double.Parse(bunifuCustomTextbox5.Text);
                    double regle = Double.Parse(bunifuCustomTextbox6.Text);
                    double reste = Double.Parse(bunifuCustomTextbox7.Text);

                   

                    string designation = bunifuCustomTextbox2.Text;
                    double quantite = Double.Parse(bunifuCustomTextbox3.Text);
                    double prixUnitaire = Double.Parse(bunifuCustomTextbox4.Text);
                    DateTime dateOperation = bunifuDatepicker1.Value;
             
                    Paiement paiement = new Paiement(modePaiement, ttc, regle, reste);

                    app.manager.addOperationClient(new OperationClient(code, client, paiement, designation, quantite, prixUnitaire, dateOperation));
                    MessageBox.Show("Operation bien ajouter, lancement de la facture attendez svp : ");
                    facture();
                    Close();
                }
                else
                    MessageBox.Show("Cette Operation existe déja");
            }
            
        }

        private void AddOperationClient_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox1.Text = app.manager.OperationClients.Count + "";
            bunifuDatepicker1.Value = DateTime.Now;
            metroComboBox2.Items.Add("Espèce");
            metroComboBox2.Items.Add("Chèque");
            metroComboBox2.Items.Add("Effet");
            metroComboBox2.SelectedIndex = 0;

            foreach(Client client in app.manager.Clients)
                metroComboBox1.Items.Add(client.Nom);
            metroComboBox1.SelectedIndex = 0;
        }

        private void bunifuCustomTextbox4_Validated(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomTextbox5.Text = (Double.Parse(bunifuCustomTextbox3.Text) * Double.Parse(bunifuCustomTextbox4.Text)) + "";
                bunifuCustomTextbox7.Text = 0 + "";
            }
            catch (Exception)
            {
            }
        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomTextbox5.Text = (Double.Parse(bunifuCustomTextbox3.Text) * Double.Parse(bunifuCustomTextbox4.Text)) + "";
                bunifuCustomTextbox7.Text = 0 + "";
            }
            catch (Exception)
            {
            }
        }

        private void facture()
        {
            //copy
            string source = app.wd + "Template/template.xlsx";
            string destination = app.wd + "FacturesClients/" +metroComboBox1.SelectedItem + "/" +  bunifuCustomTextbox1.Text + ".xlsx";


            File.Copy(source, destination);
            //File.Move();

            //write
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(destination);
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            //test
            x.Cells[9, 5] = bunifuCustomTextbox1.Text + "/" + DateTime.Now.Year;
            x.Cells[7, 2] = "Azrou le " + DateTime.Now.ToShortDateString();
            x.Cells[10, 3] = metroComboBox1.SelectedItem;
            x.Cells[24, 4] = bunifuCustomTextbox12.Text;
            x.Cells[11, 3] = bunifuCustomTextbox13.Text;
            //end test
            x.Cells[15, 3] = bunifuCustomTextbox2.Text;
            x.Cells[15, 4] = bunifuCustomTextbox3.Text;
            x.Cells[15, 6] = bunifuCustomTextbox4.Text;
            x.Cells[15, 7] = bunifuCustomTextbox5.Text;
            x.Cells[16, 7] = bunifuCustomTextbox5.Text;
            x.Cells[17, 7] = bunifuCustomTextbox8.Text;

            x.Cells[18, 7] = horsTaxe;
            x.Cells[19, 7] = tva;
            x.Cells[20, 7] = ttc;

            sheet.Close(true, Type.Missing);
            excel.Quit();
            //open
            System.Diagnostics.Process.Start(destination);
        }

      

        private void bunifuCustomTextbox8_TextChanged(object sender, EventArgs e)
        {

            try
            {
                horsTaxe = Double.Parse(bunifuCustomTextbox5.Text) - Double.Parse(bunifuCustomTextbox8.Text);
                bunifuCustomTextbox9.Text = horsTaxe + "";


                tva = horsTaxe * 0.2;
                bunifuCustomTextbox10.Text = tva + "";

                ttc = horsTaxe + tva;
                bunifuCustomTextbox11.Text = ttc + "";
                bunifuCustomTextbox6.Text = bunifuCustomTextbox11.Text;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuCustomTextbox8_Validated(object sender, EventArgs e)
        {
            try
            {
                horsTaxe = Double.Parse(bunifuCustomTextbox5.Text) - Double.Parse(bunifuCustomTextbox8.Text);
                bunifuCustomTextbox9.Text = horsTaxe + "";


                tva = horsTaxe * 0.2;
                bunifuCustomTextbox10.Text = tva + "";

                ttc = horsTaxe + tva;
                bunifuCustomTextbox11.Text = ttc + "";
            }
            catch (Exception)
            {

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
