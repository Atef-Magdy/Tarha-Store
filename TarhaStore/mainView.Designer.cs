using System.Runtime.CompilerServices;

namespace TarhaStore
{
    partial class mainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.storeDetails = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pill = new System.Windows.Forms.DataGridView();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.TextBox();
            this.total = new System.Windows.Forms.TextBox();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.print = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.back = new System.Windows.Forms.Button();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pill)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).BeginInit();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // storeDetails
            // 
            resources.ApplyResources(this.storeDetails, "storeDetails");
            this.storeDetails.Name = "storeDetails";
            this.storeDetails.UseVisualStyleBackColor = true;
            this.storeDetails.Click += new System.EventHandler(this.storeDetails_Click);
            // 
            // admin
            // 
            resources.ApplyResources(this.admin, "admin");
            this.admin.Name = "admin";
            this.admin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pill
            // 
            this.pill.AllowUserToAddRows = false;
            this.pill.AllowUserToResizeColumns = false;
            this.pill.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arabic Typesetting", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.pill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quantity,
            this.price,
            this.name});
            resources.ApplyResources(this.pill, "pill");
            this.pill.MultiSelect = false;
            this.pill.Name = "pill";
            this.pill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.pill.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Pill_UserDeletingRow);
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.quantity, "quantity");
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.price, "price");
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // discount
            // 
            resources.ApplyResources(this.discount, "discount");
            this.discount.Name = "discount";
            // 
            // total
            // 
            resources.ApplyResources(this.total, "total");
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // btnDiscount
            // 
            resources.ApplyResources(this.btnDiscount, "btnDiscount");
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // add
            // 
            resources.ApplyResources(this.add, "add");
            this.add.Name = "add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // quantityBox
            // 
            resources.ApplyResources(this.quantityBox, "quantityBox");
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.TextChanged += new System.EventHandler(this.quantityBox_TextChanged);
            // 
            // print
            // 
            resources.ApplyResources(this.print, "print");
            this.print.Name = "print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // search
            // 
            resources.ApplyResources(this.search, "search");
            this.search.Name = "search";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.storeDetails, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.admin, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.pill, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnDiscount, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel14, 1, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // tableLayoutPanel14
            // 
            resources.ApplyResources(this.tableLayoutPanel14, "tableLayoutPanel14");
            this.tableLayoutPanel14.Controls.Add(this.discount, 0, 1);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel15, 1, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // tableLayoutPanel15
            // 
            resources.ApplyResources(this.tableLayoutPanel15, "tableLayoutPanel15");
            this.tableLayoutPanel15.Controls.Add(this.total, 0, 1);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel11, 0, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel7_Paint);
            // 
            // tableLayoutPanel8
            // 
            resources.ApplyResources(this.tableLayoutPanel8, "tableLayoutPanel8");
            this.tableLayoutPanel8.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel12, 1, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            // 
            // tableLayoutPanel12
            // 
            resources.ApplyResources(this.tableLayoutPanel12, "tableLayoutPanel12");
            this.tableLayoutPanel12.Controls.Add(this.search, 0, 1);
            this.tableLayoutPanel12.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            // 
            // tableLayoutPanel9
            // 
            resources.ApplyResources(this.tableLayoutPanel9, "tableLayoutPanel9");
            this.tableLayoutPanel9.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel13, 1, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            // 
            // tableLayoutPanel13
            // 
            resources.ApplyResources(this.tableLayoutPanel13, "tableLayoutPanel13");
            this.tableLayoutPanel13.Controls.Add(this.quantityBox, 0, 1);
            this.tableLayoutPanel13.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            // 
            // tableLayoutPanel10
            // 
            resources.ApplyResources(this.tableLayoutPanel10, "tableLayoutPanel10");
            this.tableLayoutPanel10.Controls.Add(this.add, 1, 1);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            // 
            // tableLayoutPanel11
            // 
            resources.ApplyResources(this.tableLayoutPanel11, "tableLayoutPanel11");
            this.tableLayoutPanel11.Controls.Add(this.print, 1, 1);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel7);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel18);
            this.panel2.Controls.Add(this.tableLayoutPanel16);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel18
            // 
            resources.ApplyResources(this.tableLayoutPanel18, "tableLayoutPanel18");
            this.tableLayoutPanel18.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.itemsBindingSource1;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // tableLayoutPanel16
            // 
            resources.ApplyResources(this.tableLayoutPanel16, "tableLayoutPanel16");
            this.tableLayoutPanel16.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.tableLayoutPanel17, 0, 0);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tableLayoutPanel17
            // 
            resources.ApplyResources(this.tableLayoutPanel17, "tableLayoutPanel17");
            this.tableLayoutPanel17.Controls.Add(this.back, 0, 0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.Name = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // mainView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "mainView";
            this.Load += new System.EventHandler(this.form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pill)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).EndInit();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button storeDetails;
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView pill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource itemsBindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
    }
}

