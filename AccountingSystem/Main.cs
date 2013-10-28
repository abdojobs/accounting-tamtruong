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
    }
    public class foo {
        public string name { get; set; }
        public string id { get; set; }
    }
}
