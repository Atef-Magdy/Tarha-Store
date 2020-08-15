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
        int totalPrice = 0;
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
        private void Pill_UserDeletingRow(object sender,DataGridViewRowCancelEventArgs e)
        {
            int numberOfRaws = pill.SelectedRows.Count;
            int price, quantity;
            price = (int)pill.SelectedRows[0].Cells[1].Value;
            quantity = (int)pill.SelectedRows[0].Cells[0].Value;
            totalPrice -= price * quantity;
            total.Text = totalPrice.ToString();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Boolean check1, check2;
            check1 = check2 = false;
            String name = "";
            int quantity = 0;
            int price = 0;

            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            
            if(!search.Text.Equals("") && !quantityBox.Text.Equals(""))
            {
               
                connetionString = "Data Source=DESKTOP-MKVLAC4\\SQLEXPRESS; Initial Catalog=TarhaDB;Integrated Security=true;";
                string sql = "SELECT price from [TarhaDB].[dbo].[items] where name = '" + search.Text + "' ";
                connection = new SqlConnection(connetionString);
                command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (!reader.Read())
                {
                    MessageBox.Show("لا يوجد منتج بهذا الأسم");
                }
                else
                {
                    name = search.Text;
                    price = reader.GetInt32(0);
                    check1 = true;
                }
                
                if (!int.TryParse(quantityBox.Text, out quantity))
                {
                    MessageBox.Show("خانة العدد للأرقام فقط");
                }
                else
                {
                    check2 = true;
                }
            }
            else
            {
                MessageBox.Show("يوجد أحد المتطلبات فارغة ");
            }

            if(check1 && check2)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(pill);
                row.Cells[2].Value = name;
                row.Cells[1].Value = price;
                row.Cells[0].Value = quantity;
                pill.Rows.Add(row);
                search.Text = "";
                quantityBox.Text = "";
                totalPrice += price*quantity;
                total.Text = totalPrice.ToString();
            }
        }
    }
}
