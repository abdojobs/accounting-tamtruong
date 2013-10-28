using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Components
{
    public class AccountGrid : AutoGrid
    {
        public AccountGrid() : base() { 
            this.ColumnAdded+=new System.Windows.Forms.DataGridViewColumnEventHandler(AccountGrid_ColumnAdded);
        }
        protected void AccountGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            

        }
        public override void CustomizeColumn(DataGridViewColumnEventArgs e)
        {
            base.CustomizeColumn(e);
            if (e.Column.Name == "Code")
            {
                e.Column.HeaderText = "Mã tài khoản";
            }
            else if (e.Column.Name == "Description")
            {
                e.Column.HeaderText = "Diễn giải";
            }
            else
            {
                e.Column.Visible = false;
            }
        }
    }
}
