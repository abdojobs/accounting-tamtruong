using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Components
{
    public class AccountClauseGrid:AutoGrid
    {

        public override void CustomizeColumn(DataGridViewColumnEventArgs e)
        {
            base.CustomizeColumn(e);
            if (e.Column.Name == "Code")
            {
                e.Column.HeaderText = "Mã định khoản";
            }
            else if (e.Column.Name == "Description")
            {
                e.Column.HeaderText = "Diễn giải";
            }
            else if (e.Column.Name == "ProceduceType") { }
            else{
                e.Column.Visible = false;
            }
        }
    }
}
