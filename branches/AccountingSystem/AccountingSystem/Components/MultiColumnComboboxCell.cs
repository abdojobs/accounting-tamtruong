using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;

namespace AccountingSystem.Components
{
    public class MultiColumnComboboxCell : DataGridViewComboBoxCell
    {
        public delegate void CustomizeColumnHandler(object sender);
        public event CustomizeColumnHandler CustomizeMultiColumns;
        public ComboBox combobox;

        const int columnPadding = 5;
        private float[] columnWidths = new float[0];
        private String[] columnNames = new String[0];
        private int valueMemberColumnIndex = 0;
        public List<string> FieldsList { get; set; }

        public MultiColumnComboboxCell() {
            
        }

        public void RegisterEvents(ComboBox cbc) {
            combobox = cbc;
            combobox.DataSourceChanged += new EventHandler(DataSourceChanged);
            combobox.ValueMemberChanged += new EventHandler(ValueMemberChanged);
            combobox.DropDown += new EventHandler(DropDown);
            combobox.MeasureItem += new MeasureItemEventHandler(MeasureItem);
            combobox.DrawItem += new DrawItemEventHandler(DrawItem);
        }
        public void MultiColumnComboboxCell_CustomizeColumn(object sender)
        {
            combobox = (ComboBox)sender;
            
        }

        protected void DataSourceChanged(object sender,EventArgs e)
        {

            InitializeColumns();
        }

        protected void ValueMemberChanged(object sender, EventArgs e)
        {
            InitializeValueMemberColumn();
        }

        protected void DropDown(object sender, EventArgs e)
        {
            this.DropDownWidth = (int)CalculateTotalWidth();
        }

        private void InitializeColumns()
        {

            columnWidths = new float[FieldsList.Count];
            columnNames = new String[FieldsList.Count];

            for (int colIndex = 0; colIndex < FieldsList.Count; colIndex++)
            {
                String name = FieldsList[colIndex];
                columnNames[colIndex] = name;
            }
        }

        private void InitializeValueMemberColumn()
        {
            int colIndex = 0;
            foreach (String columnName in columnNames)
            {
                if (String.Compare(columnName, ValueMember, true, CultureInfo.CurrentUICulture) == 0)
                {
                    valueMemberColumnIndex = colIndex;
                    break;
                }
                colIndex++;
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

        protected  void MeasureItem(object sender,MeasureItemEventArgs e)
        {
            //base.OnMeasureItem(e);

            //if (DesignMode)
            //    return;

            for (int colIndex = 0; colIndex < columnNames.Length; colIndex++)
            {
                string item = Convert.ToString(combobox.SelectedItem);
                SizeF sizeF = e.Graphics.MeasureString(item, combobox.Font);
                columnWidths[colIndex] = Math.Max(columnWidths[colIndex], sizeF.Width);
            }

            float totWidth = CalculateTotalWidth();

            e.ItemWidth = (int)totWidth;
        }

        protected void DrawItem(object sender, DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);

            //if (DesignMode)
            //    return;

            e.DrawBackground();

            Rectangle boundsRect = e.Bounds;
            int lastRight = 0;

            using (Pen linePen = new Pen(SystemColors.GrayText))
            {
                using (SolidBrush brush = new SolidBrush(combobox.ForeColor))
                {
                    if (columnNames.Length == 0)
                    {
                        e.Graphics.DrawString(Convert.ToString(Items[e.Index]), combobox.Font, brush, boundsRect);
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < columnNames.Length; colIndex++)
                        {
                            string item = Convert.ToString(combobox.SelectedItem);

                            boundsRect.X = lastRight;
                            boundsRect.Width = (int)columnWidths[colIndex] + columnPadding;
                            lastRight = boundsRect.Right;

                            if (colIndex == valueMemberColumnIndex)
                            {
                                using (Font boldFont = new Font(combobox.Font, FontStyle.Bold))
                                {
                                    e.Graphics.DrawString(item, boldFont, brush, boundsRect);
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(item, combobox.Font, brush, boundsRect);
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

        
    }
}
