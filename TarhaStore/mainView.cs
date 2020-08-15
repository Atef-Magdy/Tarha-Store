using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarhaStore
{
    public partial class mainView : Form
    {
        public mainView()
        {
            InitializeComponent();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;

            connetionString = "Data Source=DESKTOP-MKVLAC4\\SQLEXPRESS; Initial Catalog=TarhaDB;Integrated Security=true;";
            string sql = "INSERT INTO [TarhaDB].[dbo].[items] (name , price , quantity) VALUES('harer' , 20 , 70)";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
                
            }
        }

        private void form1_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;

            connetionString = "Data Source=DESKTOP-MKVLAC4\\SQLEXPRESS; Initial Catalog=TarhaDB;Integrated Security=true;";
            string sql = "SELECT name from [TarhaDB].[dbo].[items]";
            connection = new SqlConnection(connetionString);
            command = new SqlCommand(sql, connection);
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();

            while(reader.Read())
            {
                autoText.Add(reader.GetString(0));
            }
            search.AutoCompleteMode = AutoCompleteMode.Suggest;
            search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            search.AutoCompleteCustomSource = autoText;
            connection.Close();

        }

        private void storeDetails_Click(object sender, EventArgs e)
        {
            storeDetails form2 = new storeDetails();
            form2.Show();
            this.Hide();
        }
    }
}
