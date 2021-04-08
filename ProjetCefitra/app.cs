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
    public partial class app : Form
    {
        internal static Manager manager;
        internal static DAODB dao;
        internal static DAO mysdao;

        internal static string wd = Directory.GetCurrentDirectory();
        //internal static string wd = "E:/ETUDES SUPERIEURE/Projets/2019/CEFITRA/ProjetCefitra/ProjetCefitra/";

        public app()
        {
            InitializeComponent();
            manager = new Manager();
            workingDir();
            dao = new DAODB();
            mysdao = new DAO();

            mysdao.open();
            mysdao.clearDB();
            mysdao.close();

            try
            {
                selectFromDB();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " in database.");
                manager.deserialiserXML();
            }
        }

        private void workingDir()
        {
            string[] t = wd.Split('\\');
            wd = "";
            for (int i=0; i < t.Length - 2;i++)
            {
                wd += t[i] + "/";
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            manager.serialiserXML();
            Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Hide();
            ClientForm form = new ClientForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            manager.serialiserXML();
            Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Hide();
            FournisseurForm form = new FournisseurForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuFlatButton5_Click1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            manager.serialiserXML();
            Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Hide();
            OperationCLientForm form = new OperationCLientForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void app_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            Hide();
            ClientForm form = new ClientForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            manager.serialiserXML();
            insertIntoDB();
            dao.close();
            Close();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            Hide();
            FournisseurForm form = new FournisseurForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            Hide();
            OperationCLientForm form = new OperationCLientForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            Hide();
            OperationFournisseurForm form = new OperationFournisseurForm();
            form.ShowDialog();
            Show();
        }

        private void bunifuFlatButton5_Click_2(object sender, EventArgs e)
        {
            manager.serialiserXML();
            insertIntoDB();
            dao.close();
            Close();
        }

        private void insertIntoDB()
        {
            dao.clearDB();
            dao.insertIntoClient(manager.Clients);
            dao.insertIntoFournisseur(manager.Fournisseurs);
            dao.insertIntoOperationClient(manager.OperationClients);
            dao.insertIntoOperationFournisseur(manager.OperationFournisseurs);
        }

        private void selectFromDB()
        {
            dao.selectFromClient();
            dao.selectFromFournisseur();
            dao.selectFromOperationClient();
            dao.selectFromOperationFournisseur();
        }

    }
}
