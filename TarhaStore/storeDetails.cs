using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarhaStore
{
    public partial class storeDetails : Form
    {
        public storeDetails()
        {
            InitializeComponent();
        }

        private void storeDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tarhaDBDataSet1.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.tarhaDBDataSet1.items);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backFromStore_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainView mainForm = new mainView();
            mainForm.Show();


        }
    }
}
