using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountingSystem.Utils;

namespace AccountingSystem.Components
{
    public class AutoGrid : DataGridView
    {
        /// <summary>
        /// use for handler event datagrid change row value
        /// </summary>
        /// <param name="indexRowChange"></param>
        public delegate void SaveChangeHandler(object sender,int indexRowChange);
        /// <summary>
        /// call method change value
        /// </summary>
        public event SaveChangeHandler SaveChange;
        /// <summary>
        /// use to known which row is changed
        /// </summary>
        protected int IndexRowChange { get; set; }
        public AutoGrid()
        {
            // set row is not changed yet.
            IndexRowChange = -1;
            this.CellValueChanged += new DataGridViewCellEventHandler(AutoGrid_CellValueChanged);
            this.CellEnter+=new DataGridViewCellEventHandler(AutoGrid_CellEnter);
            this.ColumnAdded+=new DataGridViewColumnEventHandler(AutoGrid_ColumnAdded);
        }

        protected void AutoGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e) {
            CustomizeColumn(e);
        }
        protected void AutoGrid_CellEnter(object sender, DataGridViewCellEventArgs e) {
            // if cell is changed inline row or has not row changed (IndexRowChange==-1)
            // then must not excute.
            if (IndexRowChange == e.RowIndex || IndexRowChange==-1)
                return;
            // else execute
            DataGridView grid = (DataGridView)sender;
            SaveChange(sender,IndexRowChange);
            // set row comeback state not changed yet.
            IndexRowChange = -1;
            
        }
        protected void AutoGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            IndexRowChange = e.RowIndex;
        }


        public virtual void CustomizeColumn(DataGridViewColumnEventArgs e)
        {
            
        }
    }
}
