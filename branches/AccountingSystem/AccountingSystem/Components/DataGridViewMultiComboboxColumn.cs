using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace AccountingSystem.Components
{
    public class DataGridViewMultiComboboxColumn : DataGridViewComboBoxColumn
    {
        private string[] columnNames = new string[0];
        private float[] columnWidths = new float[0];
        const int columnPadding = 5;
        private int valueMemberColumnIndex = 0;
        private int columnCount;
        private bool isCreate=false;
        private DataGridView SelfGridView;
        private List<string> columnNameOfSelfGridView;

        public void SetupColumn() {
            if (this.DataGridView != null)
            {
                SelfGridView = this.DataGridView;
                SelfGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DataGridView_EditingControlShowing);
                InitializeColumns();
            }
        }
        void InitializeColumns()
        {
            if (!(this.DataSource is DataTable))
                throw new NotSupportedException("ComboDataSource only support DataTable type.");
            if (this.DataSource == null)
                throw new NoNullAllowedException("ComboDataSource no null allowed.");
            DataTable tb = this.DataSource as DataTable;
            columnCount = tb.Columns.Count;
            columnWidths = new float[columnCount];
            columnNames = new string[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                columnNames[i] = tb.Columns[i].ColumnName;
            }
            // get columnnames for SelfGridView
            columnNameOfSelfGridView = new List<string>();
            foreach (DataGridViewColumn col in SelfGridView.Columns) {
                columnNameOfSelfGridView.Add(col.Name);
            }
        }
        protected void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (e.Control is ComboBox && !isCreate)
            {
                ComboBox combo = e.Control as ComboBox;
                InitializeCombo(combo);
                isCreate = true;
                //register event combobox change
                combo.SelectionChangeCommitted+=new EventHandler(combo_SelectionChangeCommitted);
            }
        }
        void combo_SelectionChangeCommitted(object sender, EventArgs e) {
            ComboBox combo = sender as ComboBox;
            DataRowView item = combo.SelectedItem as DataRowView;
            string colname = SelfGridView.Columns[SelfGridView.CurrentCell.ColumnIndex].Name;
            if (item != null)
            {
                if (colname == this.Name)
                {
                    foreach (var name in columnNames)
                    {
                        if (name != this.DataPropertyName && name != this.ValueMember && columnNameOfSelfGridView.Contains(name))
                        {
                            SelfGridView.CurrentRow.Cells[name].Value = item.Row[name];
                        }
                    }
                }
            }
        }
        void InitializeCombo(ComboBox combo)
        {

            combo.DrawMode = DrawMode.OwnerDrawVariable;
            combo.MeasureItem -= new MeasureItemEventHandler(MeasureItem);
            combo.MeasureItem += new MeasureItemEventHandler(MeasureItem);
            combo.DrawItem -= new DrawItemEventHandler(DrawItem);
            combo.DrawItem += new DrawItemEventHandler(DrawItem);
        }
        
        void DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            ComboBox cb = (ComboBox)sender;
            e.DrawBackground();

            Rectangle boundsRect = e.Bounds;
            int lastRight = 0;

            using (Pen linePen = new Pen(SystemColors.GrayText))
            {
                using (SolidBrush brush = new SolidBrush(cb.ForeColor))
                {
                    if (columnNames.Length == 0)
                    {
                        e.Graphics.DrawString(cb.Items[e.Index].ToString(), cb.Font, brush, boundsRect);
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < columnNames.Length; colIndex++)
                        {
                            // no draw if column is valuemember in combobox column
                            if (columnNames[colIndex] == this.ValueMember)
                                continue;
                            string item = ((DataRowView)cb.Items[e.Index])[colIndex].ToString();

                            boundsRect.X = lastRight;
                            boundsRect.Width = (int)columnWidths[colIndex] + columnPadding;
                            lastRight = boundsRect.Right;

                            if (colIndex == valueMemberColumnIndex)
                            {
                                using (Font boldFont = new Font(cb.Font, FontStyle.Bold))
                                {
                                    e.Graphics.DrawString(item, boldFont, brush, boundsRect);
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(item, cb.Font, brush, boundsRect);
                            }

                            if (colIndex < columnNames.Length - 1)
                            {
                                e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                            }
                        }
                    }
                }
            }

            e.DrawFocusRectangle();
        }
        void MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            for (int colIndex = 0; colIndex < columnNames.Length; colIndex++)
            {
                string item = ((DataRowView)combo.Items[e.Index])[colIndex].ToString();
                SizeF sizeF = e.Graphics.MeasureString(item, combo.Font);
                columnWidths[colIndex] = Math.Max(columnWidths[colIndex], sizeF.Width);
            }

            float totWidth = CalculateTotalWidth();

            e.ItemWidth = (int)totWidth;
        }
        private float CalculateTotalWidth()
        {
            float totWidth = 0;
            foreach (int width in columnWidths)
            {
                totWidth += (width + columnPadding);
            }
            return totWidth + SystemInformation.VerticalScrollBarWidth;
        }
    }
}
