using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess.Repositories;
using AccountingSystem.Utils;
using AccountingSystem.Controls;
using DataAccess.Entities;
using System.Data.SqlClient;

namespace AccountingSystem
{
    public partial class Main : Form
    {
        protected AccountControl account;
        AccountClauseControl accountClause;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //account = new AccountControl();
            //account.Dock = DockStyle.Fill;
            //plcontainer.Panel2.Controls.Clear();
            //plcontainer.Panel2.Controls.Add(account);

            accountClause = new AccountClauseControl();
            accountClause.Dock = DockStyle.Fill;
            plcontainer.Panel2.Controls.Clear();
            plcontainer.Panel2.Controls.Add(accountClause);
            GetData();
            
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            string a = string.Empty;
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            string a = string.Empty;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            string a = string.Empty;
        }

        private void dataGridView1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            string a = string.Empty;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            string a = string.Empty;
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            string a = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account a = account.gridAccount1.CurrentRow.DataBoundItem as Account;
            BaseConnector connect = new BaseConnector();
            connect.Context.Accounts.AddSubmit(a);
        }

        protected void GetData() {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =@"Data Source=.\SQLExpress;Initial Catalog=Ketoan;User ID=sa;Password=aaa111";

                // Create a new data adapter based on the specified query.
                string selectCommand = "Select * from Account";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                //dataGridView1.DataSource = bindingSource1;
                //((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).DataSource = null;
                //((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).DataPropertyName = "Id";
                //((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).ValueMember = "Id";
                //((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).ValueType = typeof(int);
                //((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).DisplayMember = "Code";

                //DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                //col1.Name = "Id";
                //col1.HeaderText = "Ma";

                //DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                //col2.Name = "Code";
                //col2.HeaderText = "Mo ta";

                //dataGridView1.Columns.Add(col1);
                //dataGridView1.Columns.Add(col2);

                //dataGridView1.Rows.Add(new List<object>() { 1, "item 1" });
                //dataGridView1.Rows.Add(new List<object>() { 2, "item 2" });
                //dataGridView1.Rows.Add(new List<object>() { 3, "item 3" });
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                //dt.Rows.Add("foo");
                //dt.Rows.Add("dsnv");
                //dt.Rows.Add("nv");
                //dt.Rows.Add(new object[] { null });
                dt.Rows.Add(DBNull.Value);

                Binding b = new Binding("Text", dt, "Name", true);
                b.NullValue = "nv";
                b.DataSourceNullValue = "dsnv";
                this.textBox1.DataBindings.Add(b);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
    }
    public class foo {
        public string name { get; set; }
        public string id { get; set; }
    }
}
