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
    public partial class AddOperationFournisseur : Form
    {
        double horsTaxe;
        double tva;
        double ttc;

        public AddOperationFournisseur()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox1.Text == "")
            {
                MessageBox.Show("Le code est obligatoire");
            }
            else
            {
                if (app.manager.searchOperationFournisseurByCode(bunifuCustomTextbox1.Text) == null)
                {
                    string code = bunifuCustomTextbox1.Text;
                    Fournisseur fournisseur = app.manager.searchFournisseurByKey((string)metroComboBox1.SelectedItem)[0];


                    string modePaiement = (string)metroComboBox2.SelectedItem;
                    double montant = Double.Parse(bunifuCustomTextbox5.Text);
                    double regle = Double.Parse(bunifuCustomTextbox6.Text);
                    double reste = Double.Parse(bunifuCustomTextbox7.Text);

                    Paiement paiement = new Paiement(modePaiement, ttc, regle, reste);

                    string designation = bunifuCustomTextbox2.Text;
                    double quantite = Double.Parse(bunifuCustomTextbox3.Text);
                    double prixUnitaire = Double.Parse(bunifuCustomTextbox4.Text);
                    DateTime dateOperation = bunifuDatepicker1.Value;

                    app.manager.addOperationFournisseur(new OperationFournisseur(code, fournisseur, paiement, designation, quantite, prixUnitaire, dateOperation));
                    MessageBox.Show("Operation bien ajouter, lancement de la facture attendez svp : ");
                    facture();
                    Close();
                }
                else
                    MessageBox.Show("Cette Operation existe déja");
            }
        }

        private void AddOperationFournisseur_Load(object sender, EventArgs e)
        {
            bunifuDatepicker1.Value = DateTime.Now;
            metroComboBox2.Items.Add("Espèce");
            metroComboBox2.Items.Add("Chèque");
            metroComboBox2.Items.Add("Effet");
            metroComboBox2.SelectedIndex = 0;

            foreach (Fournisseur fournisseur in app.manager.Fournisseurs)
                metroComboBox1.Items.Add(fournisseur.Nom);
            metroComboBox1.SelectedIndex = 0;
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

        private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
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

        private void bunifuCustomTextbox3_Validated(object sender, EventArgs e)
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

        private void bunifuCustomTextbox4_TextChanged_1(object sender, EventArgs e)
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

        private void bunifuCustomTextbox4_Validated_1(object sender, EventArgs e)
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
                bunifuCustomTextbox6.Text = bunifuCustomTextbox11.Text;
            }
            catch (Exception)
            {

            }
        }

        private void facture()
        {
            //copy
            string source = app.wd + "Template/template.xlsx";
            string destination = app.wd + "FacturesFournisseurs/" + metroComboBox1.SelectedItem + "/" + bunifuCustomTextbox1.Text + ".xlsx";


            File.Copy(source, destination);
            //File.Move();

            //write
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(destination);
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;


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

    }
}
