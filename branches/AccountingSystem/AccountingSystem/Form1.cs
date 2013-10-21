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

namespace AccountingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //BaseConnector connector = new BaseConnector();
            //dtg.DataSource = connector.Context.Accounts.GetAll().ToList();
            ErrorProvider error = new ErrorProvider();
            ErrorManager.Error(txt1, "Not an integer value.");
            ErrorManager.Error(txt2, "Not an integer value.");
            //error.SetError(txt2, "Not an integer value.");
        }
    }
}
