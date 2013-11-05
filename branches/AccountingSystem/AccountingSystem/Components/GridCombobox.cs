using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace AccountingSystem.Components
{
    public class GridCombobox : DataGridView
    {
        private object ComboDataSource { get; set; }
        private string[] columnNames = new string[0];
        private float[] columnWidths = new float[0];
        const int columnPadding = 5;
        private int valueMemberColumnIndex = 0;
        private int columnCount;
        public DataGridViewComboBoxColumn comboboxColumn { get; set; }

        public GridCombobox()
        {
            this.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(GridCombobox_EditingControlShowing);
        }
        public void AddComboColumn(DataGridViewComboBoxColumn column) {
            comboboxColumn = column;
            this.Columns.Add(comboboxColumn);
            InitializeColumns();
        }
        protected void GridCombobox_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                InitializeCombo(e.Control as ComboBox);
            }
        }
        void InitializeCombo(ComboBox combo)
        {
            
            combo.DrawMode = DrawMode.OwnerDrawVariable;
            combo.MeasureItem += new MeasureItemEventHandler(MeasureItem);
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
                SizeF sizeF = e.Graphics.MeasureString(item, Font);
                columnWidths[colIndex] = Math.Max(columnWidths[colIndex], sizeF.Width);
            }

            float totWidth = CalculateTotalWidth();

            e.ItemWidth = (int)totWidth;
        }
        void InitializeColumns()
        {
            if (comboboxColumn == null)
                throw new NoNullAllowedException("ComboBoxColumn no null allowed.");
            ComboDataSource = comboboxColumn.DataSource;
            if (!(ComboDataSource is DataTable))
                throw new NotSupportedException("ComboDataSource only support DataTable type.");
            if (ComboDataSource == null)
                throw new NoNullAllowedException("ComboDataSource no null allowed.");
            DataTable tb = ComboDataSource as DataTable;
            columnCount = tb.Columns.Count;
            columnWidths = new float[columnCount];
            columnNames = new string[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                columnNames[i] = tb.Columns[i].ColumnName;
            }
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
