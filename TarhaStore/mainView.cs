using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using DGVPrinterHelper;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;

namespace TarhaStore
{
    public partial class mainView : Form
    {
        String connetionString = "Data Source=DESKTOP-MKVLAC4\\SQLEXPRESS; Initial Catalog=TarhaDB;Integrated Security=true;";
        List<Panel> panels = new List<Panel>();
        int totalPrice = 0;
        private static ArrayList listName = new ArrayList();
        private static ArrayList listQuantity = new ArrayList();
        private static ArrayList listPrice = new ArrayList();
        Boolean checkDiscount = false;
        String discountPrecentage = "";


        public mainView()
        {
            InitializeComponent();
        }
        // Main from (Load)
        private void form1_Load(object sender, EventArgs e)
        {
            panels.Add(MainPanel);
            panels.Add(StockPanel);
            panels.Add(AdminPanel);
            panels[0].BringToFront();
            autoComplete();
            search.Focus();
            search.Select();
        }
        //Auto Complete Function
        private void autoComplete()
        {
            SqlConnection connection;
            SqlCommand command;

            string sql = "SELECT name from [TarhaDB].[dbo].[items]";
            connection = new SqlConnection(connetionString);
            command = new SqlCommand(sql, connection);
            // Open connection and read from database
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                autoText.Add(reader.GetString(0));
            }
            // Auto complete for the search box in main page
            search.AutoCompleteMode = AutoCompleteMode.Suggest;
            search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            search.AutoCompleteCustomSource = autoText;
            // Auto complete for the search box in admin page
            searchBynameEditing.AutoCompleteMode = AutoCompleteMode.Suggest;
            searchBynameEditing.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchBynameEditing.AutoCompleteCustomSource = autoText;

            connection.Close();
        }
        //-----------------------------------------------------------------------------------------------
        
        //Adding button in main panel
        private void add_Click(object sender, EventArgs e)
        {
            Boolean check1, check2;
            check1 = check2 = false;
            String name = "";
            int quantity = 0;
            int price = 0;
            int realQuantity = 0;
            int newQuantity = 0;

            SqlConnection connection;
            SqlCommand command;
            string sql = "SELECT price from [TarhaDB].[dbo].[items] where name = N'" + search.Text + "' ";
            connection = new SqlConnection(connetionString);
            command = new SqlCommand(sql, connection);
            SqlDataReader reader;
            SqlDataReader DBQuantityReader;

            if (!search.Text.Equals("") && !quantityBox.Text.Equals(""))
            {
                connection.Open();
                reader = command.ExecuteReader();
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

                connection.Close();
            }
            else
            {
                MessageBox.Show("يوجد أحد المتطلبات فارغة ");
            }

            if(check1 && check2)
            {
                connection.Open();
                sql = "SELECT quantity from [TarhaDB].[dbo].[items] where name = N'" + search.Text + "'";
                command = new SqlCommand(sql, connection);
                DBQuantityReader = command.ExecuteReader();
                if(DBQuantityReader.Read())
                {
                    //Real quantity in DB
                    realQuantity = DBQuantityReader.GetInt32(0);
                    connection.Close();
                    //Check if quantity in database is enough for the order
                    if (realQuantity >= quantity)
                    {
                        //Adding the order to the pill(dataGridView)
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(pill);
                        row.Cells[2].Value = name;
                        row.Cells[1].Value = price*quantity;
                        row.Cells[0].Value = quantity;
                        pill.Rows.Add(row);
                        totalPrice += price * quantity;
                        total.Text = totalPrice.ToString();

                        //Calculate the new quantity to update database by it
                        newQuantity = realQuantity - quantity;
                        connection.Open();
                        sql = "UPDATE [TarhaDB].[dbo].[items] SET quantity = '" + newQuantity + "' WHERE name = N'" + search.Text + "'";
                        command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                        command.Dispose();
                        
                        //Clear fields
                        search.Text = "";
                        quantityBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("لا توجد كمية كافية ف المخزن، أضف كمية أولاُ");
                    }
                }
                connection.Close();
            }
        }
        //---------------------------------------------------------------------------------------------

        //Remove raw in main panel datagrid view
        private void Pill_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //Update Total number
            int numberOfRaws = pill.SelectedRows.Count;
            int price, quantity;
            price = (int)pill.SelectedRows[0].Cells[1].Value;
            quantity = (int)pill.SelectedRows[0].Cells[0].Value;
            totalPrice -= price;
            total.Text = totalPrice.ToString();

            //Update DB number
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader reader;

            String name = pill.SelectedRows[0].Cells[2].Value.ToString();
            int realQuantity;

            string sql = "SELECT quantity from [TarhaDB].[dbo].[items] where name = N'" + name + "' ";
            connection = new SqlConnection(connetionString);
            command = new SqlCommand(sql, connection);
            connection.Open();
            reader = command.ExecuteReader();
            
            if(reader.Read())
            {
                realQuantity = reader.GetInt32(0);
                realQuantity += quantity;
                
                connection.Close();

                connection.Open();
                
                sql = "UPDATE [TarhaDB].[dbo].[items] SET quantity = '" + realQuantity + "' WHERE name = N'" + name + "'";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            connection.Close();
        }
        //---------------------------------------------------------------------------------------------

        //Store button
        private void storeDetails_Click(object sender, EventArgs e)
        {
            panels[1].BringToFront();
            GetData();
            updateDatagrid(storeDetailsGrid);
        }

        //Back from store deatails
        private void back_Click(object sender, EventArgs e)
        {
            panels[0].BringToFront();
        }

        //Admin button
        private void admin_Click(object sender, EventArgs e)
        {
            String message = "أدخل رمز الدخول" 
                , title = "رمز دخول المسئول";
            object myValue;
            myValue = Interaction.InputBox(message, title);
            if((String)myValue == "yasmin&moustafa")
            {
                panels[2].BringToFront();
                GetData();
                updateDatagrid(adminGrid);
            }
        }
        //Back from admin
        private void backFromAdmin_Click_1(object sender, EventArgs e)
        {
            panels[0].BringToFront();
        }

        //Print Button
        private void print_Click(object sender, EventArgs e)
        {
            /*
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
           */
            printDocument1.PrinterSettings.PrinterName = "POS-80";
            printDocument1.PrinterSettings.Copies = 2;
            printDocument1.Print();
            pill.Rows.Clear();
            total.Text = "";
            totalPrice = 0;
            
        }



        //Set of functions to fill data gridViews

        private void GetData()
        {
            listName.Clear();
            listPrice.Clear();
            listQuantity.Clear();
            try
            {
                SqlConnection connection;
                SqlCommand command;
                connection = new SqlConnection(connetionString);
                
                string sql = "SELECT name, quantity, price from [TarhaDB].[dbo].[items]";
                command = new SqlCommand(sql, connection);
                connection.Open();

                //SqlDataReader row;  
                SqlDataReader row;
                row = command.ExecuteReader();
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        listName.Add(row["name"].ToString());
                        listQuantity.Add(row["quantity"].ToString());
                        listPrice.Add(row["price"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Data not found");
                }
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void updateDatagrid(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

            for (int i = 0; i < listName.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGrid);

                newRow.Cells[0].Value = listPrice[i];
                newRow.Cells[1].Value = listQuantity[i];
                newRow.Cells[2].Value = listName[i];
                
                dataGrid.Rows.Add(newRow);
            }
        }

        private void addingTypebtn_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            int price = 0;
            if(!addingTypeName.Text.Equals("") && !addingTypePrice.Text.Equals("") && !addingTypeQuantity.Text.Equals(""))
            {
                if (!int.TryParse(addingTypePrice.Text, out price) || !int.TryParse(addingTypeQuantity.Text, out quantity))
                {
                    MessageBox.Show("خانة العدد والسعر للأرقام فقط");
                }
                else
                {
                    SqlConnection connection;
                    SqlCommand command;

                    string sql = "INSERT INTO [TarhaDB].[dbo].[items] (name , price , quantity) VALUES(N'"+ addingTypeName.Text +"'  , '" + int.Parse(addingTypePrice.Text) +"' , '" + int.Parse(addingTypeQuantity.Text) + "')";
                    connection = new SqlConnection(connetionString);
                    try
                    {
                        connection.Open();
                        command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                        command.Dispose();
                        connection.Close();
                        GetData();
                        updateDatagrid(adminGrid);
                        autoComplete();
                        addingTypeName.Text = addingTypePrice.Text = addingTypeQuantity.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not open connection ! " + ex);

                    }
                }
            }
            else
            {
                MessageBox.Show("يوجد أحد المتطلبات فارغة ");
            }
        }

        private void editBynameBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            SqlCommand command;
            connection = new SqlConnection(connetionString);
            
            string sql = "SELECT price from [TarhaDB].[dbo].[items] where name = N'" + searchBynameEditing.Text + "' ";
            command = new SqlCommand(sql, connection);
            
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("لا يوجد منتج بهذا الأسم");
                connection.Close();
            }
            else
            {
                if (!editingValue.Text.Equals(""))
                {
                    connection.Close();
                    sql = "UPDATE [TarhaDB].[dbo].[items] SET name = N'" + editingValue.Text + "' WHERE name = N'" + searchBynameEditing.Text + "'";
                    command = new SqlCommand(sql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    GetData();
                    updateDatagrid(adminGrid);
                    autoComplete();
                    searchBynameEditing.Text = editingValue.Text = "";
                }
                else
                {
                    MessageBox.Show("يوجد أحد المتطلبات فارغة ");
                }
            }
            connection.Close();
        }

        private void editByQuantityBtn_Click(object sender, EventArgs e)
        {
            int checkParsing;
            SqlConnection connection;
            SqlCommand command;
            connection = new SqlConnection(connetionString);

            string sql = "SELECT price from [TarhaDB].[dbo].[items] where name = N'" + searchBynameEditing.Text + "' ";
            command = new SqlCommand(sql, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("لا يوجد منتج بهذا الأسم");
                connection.Close();
            }
            else
            {
                if (!editingValue.Text.Equals("") && int.TryParse(editingValue.Text, out checkParsing))
                {
                    connection.Close();
                    sql = "UPDATE [TarhaDB].[dbo].[items] SET quantity = '" + int.Parse(editingValue.Text) + "' WHERE name = N'" + searchBynameEditing.Text + "'";
                    command = new SqlCommand(sql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    GetData();
                    updateDatagrid(adminGrid);
                    searchBynameEditing.Text = editingValue.Text = "";
                }
                else
                {
                    MessageBox.Show("يجب إدخال رقم في خانة التعديل ");
                }
            }
            connection.Close();
        }

        private void editByPriceBtn_Click(object sender, EventArgs e)
        {
            int checkParsing;
            SqlConnection connection;
            SqlCommand command;
            connection = new SqlConnection(connetionString);

            string sql = "SELECT price from [TarhaDB].[dbo].[items] where name = N'" + searchBynameEditing.Text + "' ";
            command = new SqlCommand(sql, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("لا يوجد منتج بهذا الأسم");
                connection.Close();
            }
            else
            {
                if (!editingValue.Text.Equals("") && int.TryParse(editingValue.Text, out checkParsing))
                {
                    connection.Close();
                    sql = "UPDATE [TarhaDB].[dbo].[items] SET price = '" + int.Parse(editingValue.Text) + "' WHERE name = N'" + searchBynameEditing.Text + "'";
                    command = new SqlCommand(sql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    GetData();
                    updateDatagrid(adminGrid);
                    searchBynameEditing.Text = editingValue.Text = "";
                }
                else
                {
                    MessageBox.Show("يجب إدخال رقم في خانة التعديل ");
                }
            }
            connection.Close();
        }

        private void deleteTpe_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            SqlCommand command;
            connection = new SqlConnection(connetionString);

            string sql = "SELECT price from [TarhaDB].[dbo].[items] where name = N'" + searchBynameEditing.Text + "' ";
            command = new SqlCommand(sql, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("لا يوجد منتج بهذا الأسم");
                connection.Close();
            }
            else
            {
                connection.Close();
                sql = "DELETE FROM [TarhaDB].[dbo].[items] WHERE name = N'" + searchBynameEditing.Text + "'";
                command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

                GetData();
                updateDatagrid(adminGrid);
                autoComplete();
                searchBynameEditing.Text = editingValue.Text = "";
            }
            connection.Close();
        }

        private void tableLayoutPanel24_Paint(object sender, PaintEventArgs e)
        {

        }

        //Pill Drawing
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Page boundries
            float pWidth = e.PageBounds.Width;
            float pheight = e.PageBounds.Height;
            
            //Logo details
            Font logoFont = new Font("Arial", 34, FontStyle.Italic);
            SizeF logoSize = e.Graphics.MeasureString("طرحة", logoFont);

            Font subLogo = new Font("Arial", 16, FontStyle.Bold);
            SizeF subLogoSize = e.Graphics.MeasureString("ياسمين", subLogo);

            //Date details
            String date = DateTime.Now.ToString("dd/MM/yyy H:mm");
            date += " : التاريخ";
            Font dateFont = new Font("Arial", 16, FontStyle.Regular);
            SizeF dateSize = e.Graphics.MeasureString(date, dateFont);

            //Header Drawing
            e.Graphics.DrawString("طرحة", logoFont, Brushes.Black, (pWidth - logoSize.Width) / 2, 10);
            e.Graphics.DrawString("ياسمين", subLogo, Brushes.Black, (pWidth - logoSize.Width) / 2 - subLogoSize.Width + 10, 30);
            e.Graphics.DrawString(date, dateFont, Brushes.Black, (pWidth - dateSize.Width) / 2, logoSize.Height+15);

            //Line
            float headerPreHeight = 10 + logoSize.Height + 5 + dateSize.Height;
            e.Graphics.DrawLine(Pens.Black, 0,headerPreHeight, pWidth , headerPreHeight);

            //Pill Header
            Font bodyFont = new Font("Arial", 14, FontStyle.Regular);
            String gridName = "الاسم";
            String gridQuantity = "العدد";
            String gridPrice = "السعر";
            SizeF nameSize = e.Graphics.MeasureString(gridName, bodyFont);
            SizeF quantitySize = e.Graphics.MeasureString(gridQuantity, bodyFont);
            SizeF priceSize = e.Graphics.MeasureString(gridPrice, bodyFont);

            e.Graphics.DrawString(gridName, bodyFont, Brushes.Black, pWidth-nameSize.Width , headerPreHeight + 2);
            e.Graphics.DrawString(gridPrice, bodyFont, Brushes.Black, (pWidth-priceSize.Width)-(pWidth/2), headerPreHeight + 2);
            e.Graphics.DrawString(gridQuantity,bodyFont, Brushes.Black,(pWidth-quantitySize.Width)-(3*pWidth/4),headerPreHeight+ 2);

          
            //Pill DataGrid
            SizeF cellSize;
            Boolean name = true , quantity = false , price = false;
            float bodyPreHeight = headerPreHeight + 5;
            float cellDownMargin = 25;

            for(int i=0; i < pill.Rows.Count; i++)
            {
                for(int j= pill.Rows[i].Cells.Count-1; j >= 0; j--)
                {
                    String cell = pill.Rows[i].Cells[j].Value.ToString();
                    cellSize = e.Graphics.MeasureString(cell, bodyFont);

                    if(name == true)
                    {
                        bodyPreHeight += cellDownMargin;
                        e.Graphics.DrawString(cell, bodyFont, Brushes.Black , pWidth-cellSize.Width , bodyPreHeight);
                        name = false;
                        quantity = true;
                    }
                    else if(quantity == true)
                    {
                        e.Graphics.DrawString(cell, bodyFont, Brushes.Black,(pWidth - cellSize.Width)-(pWidth/2)-5,bodyPreHeight);
                        quantity = false;
                        price = true;
                    }
                    else if(price == true)
                    {
                        e.Graphics.DrawString(cell, bodyFont, Brushes.Black, (pWidth-cellSize.Width)-(3*pWidth/4)-5, bodyPreHeight);
                        price = false;
                        name = true;
                    }
                }
            }
            //Line
            e.Graphics.DrawLine(Pens.Black, 0, bodyPreHeight+25, pWidth, bodyPreHeight+25);
            
            //Total Section
            float footerPreheight = bodyPreHeight +35;
            SizeF totalName = e.Graphics.MeasureString(" : الإجمالي", bodyFont);
            String totalString = total.Text.ToString();
            SizeF totalStringSize = e.Graphics.MeasureString(totalString, bodyFont);
            float totalWidthMargin = pWidth - totalName.Width - totalStringSize.Width - 10;

            e.Graphics.DrawString(" : الإجمالي", bodyFont, Brushes.Black, pWidth-totalName.Width , footerPreheight);
            e.Graphics.DrawString(totalString, bodyFont, Brushes.Black,totalWidthMargin , footerPreheight);

            //Seller Name
            String seller = sellerName.Text;
            String sellerLabel = " : البائع";
            SizeF sellerSize = e.Graphics.MeasureString(seller, bodyFont);
            SizeF sellerLabelSize = e.Graphics.MeasureString(sellerLabel, bodyFont);

            e.Graphics.DrawString(sellerLabel, bodyFont, Brushes.Black, (pWidth - sellerLabelSize.Width) - (pWidth / 2), footerPreheight);
            e.Graphics.DrawString(seller, bodyFont, Brushes.Black, (pWidth - sellerLabelSize.Width) - (pWidth / 2) - sellerSize.Width, footerPreheight);

            //Line
            e.Graphics.DrawLine(Pens.Black, 0, footerPreheight+30, pWidth, footerPreheight+30);
            
            //Discount Section
            Font footerFont = new Font("Arial", 10, FontStyle.Regular);
            if(checkDiscount)
            {
                String discoutName = " : الخصم";
                SizeF discoutnNameSize = e.Graphics.MeasureString(discoutName , bodyFont);
                SizeF discountValueSize = e.Graphics.MeasureString(discountPrecentage, bodyFont);

                e.Graphics.DrawString(discoutName, bodyFont, Brushes.Black, pWidth - discoutnNameSize.Width, footerPreheight +40);
                e.Graphics.DrawString(discountPrecentage, bodyFont, Brushes.Black, pWidth - discoutnNameSize.Width - discountValueSize.Width - 10, footerPreheight + 40);
            }

            //Footer
            SizeF footerSize = e.Graphics.MeasureString("زورونا عبر الفيس بوك : طرحة", footerFont);
            if(checkDiscount)
            {
                e.Graphics.DrawLine(Pens.Black, 0, footerPreheight + 65, pWidth, footerPreheight + 65);
                e.Graphics.DrawString("زورونا عبر الفيس بوك : طرحة", footerFont, Brushes.Black, (pWidth - footerSize.Width) / 2, footerPreheight + 70);
            }
            else
                e.Graphics.DrawString("زورونا عبر الفيس بوك : طرحة", footerFont, Brushes.Black, (pWidth - footerSize.Width) / 2, footerPreheight + 35);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                SqlConnection connection;
                SqlCommand command;
                SqlDataReader reader;
                connection = new SqlConnection(connetionString);
                String sql;
                String name;
                int quantity;
                ArrayList DBQuantity = new ArrayList();
                Boolean checkUpdate = false;

                connection.Open();

                for (int i = 0; i < pill.Rows.Count; i++)
                {
                    String selectName = pill.Rows[i].Cells[2].Value.ToString();
                    sql = "SELECT quantity from [TarhaDB].[dbo].[items] where name = N'" + selectName + "'";
                    command = new SqlCommand(sql, connection);
                    reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        checkUpdate = true;
                        MessageBox.Show("تم إرجاع الطلبات إلي قاعدة البيانات");
                        DBQuantity.Add(reader.GetInt32(0));
                    }
                }
                connection.Close();

                if(checkUpdate)
                {
                    connection.Open();
                    for (int i = 0; i < pill.Rows.Count; i++)
                    {
                        name = pill.Rows[i].Cells[2].Value.ToString();
                        quantity = (int)pill.Rows[i].Cells[0].Value;
                        quantity += (int)DBQuantity[i];
                        sql = "UPDATE [TarhaDB].[dbo].[items] SET quantity = '"+ quantity +"' WHERE name = N'" + name + "'";
                        command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                }
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            string discountValue;
            int realDiscount;
            if(!total.Text.Equals(""))
            {
                int newTotal, currentTotal = int.Parse(total.Text);
                discountValue = discount.Text;
                if(discountValue == "yasmin10")
                {
                    checkDiscount = true;
                    realDiscount = 10 * currentTotal / 100;
                    newTotal = currentTotal - realDiscount;
                    total.Text = newTotal.ToString();
                    discount.Text = "";
                    discountPrecentage = "10%";
                }
                if (discountValue == "yasmin15")
                {
                    checkDiscount = true;
                    realDiscount = 15 * currentTotal / 100;
                    newTotal = currentTotal - realDiscount;
                    total.Text = newTotal.ToString();
                    discount.Text = "";
                    discountPrecentage = "15%";
                }
                if (discountValue == "yasmin20")
                {
                    checkDiscount = true;
                    realDiscount = 20 * currentTotal / 100;
                    newTotal = currentTotal - realDiscount;
                    total.Text = newTotal.ToString();
                    discount.Text = "";
                    discountPrecentage = "20%";
                }
                if (discountValue == "yasmin25")
                {
                    checkDiscount = true;
                    realDiscount = 25 * currentTotal / 100;
                    newTotal = currentTotal - realDiscount;
                    total.Text = newTotal.ToString();
                    discount.Text = "";
                    discountPrecentage = "25%";
                }
                if (discountValue == "yasmin30")
                {
                    checkDiscount = true;
                    realDiscount = 30 * currentTotal / 100;
                    newTotal = currentTotal - realDiscount;
                    total.Text = newTotal.ToString();
                    discount.Text = "";
                    discountPrecentage = "30%";
                }
            }
        }
    }
}
