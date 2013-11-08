using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Business.ServiceInterfaces;
using Business.Business;

namespace AccountingSystem.Controls
{
    public partial class ReceiptControl : UserControl
    {
        IReceiptBusiness _receiptsManagement;
        IReceiptBusiness receiptsManagement {
            get {
                if (_receiptsManagement == null)
                    _receiptsManagement = new ReceiptService();
                return _receiptsManagement;
            }
        }
        public ReceiptControl()
        {
            InitializeComponent();
        }
    }
}
