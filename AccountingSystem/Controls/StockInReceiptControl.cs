using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountBusiness.Business.ServiceInterfaces;
using AccountBusiness.Business;
using Business.Business.ServiceInterfaces;
using Business.Business;

namespace AccountingSystem.Controls
{
    public partial class StockInReceiptControl : UserControl
    {
        #region fields
        DataTable _tbStock;
        DataTable _tbDeliveryPerson;
        DataTable _tbAccountClause;
        DataTable _tbVatType;
        DataTable _tbTax;
        DataTable _tbDiscount;
        DataTable _tbSupplier;

        IMainBusiness _mainManager;
        IReceiptBusiness _receiptManager;
        IAccountClauseBusiness _accountClauseManager;
        IInvoiceBusiness _invoiceManager;

        #endregion

        #region manager area
        public IInvoiceBusiness InvoiceManager
        {
            get
            {
                if (_invoiceManager == null)
                {
                    _invoiceManager = new InvoiceService();
                }
                return _invoiceManager;
            }
            set { _invoiceManager = value; }
        }
        public IAccountClauseBusiness AccountClauseManager
        {
            get
            {
                if (_accountClauseManager == null)
                    _accountClauseManager = new AccountClauseService();
                return _accountClauseManager;
            }
            set { _accountClauseManager = value; }
        }
        public IReceiptBusiness ReceiptManager
        {
            get
            {
                if (_receiptManager == null)
                    _receiptManager = new ReceiptService();
                return _receiptManager;
            }
            set { _receiptManager = value; }
        }
        public IMainBusiness MainManager
        {
            get {
                if (_mainManager == null) {
                    _mainManager = new MainService();
                }
                return _mainManager;
            }
            set { _mainManager = value; }
        }
        #endregion

        #region Properties
        public DataTable TbStock
        {
            get {
                if (_tbStock == null) {
                    _tbStock = new DataTable();
                    _tbStock.Columns.Add("Id",typeof(int));
                    _tbStock.Columns.Add("Name");
                    _tbStock.Columns.Add("SellPrice",typeof(decimal));
                    _tbStock.Columns.Add("MensuralUnit");

                    var query = MainManager.GetStocks();
                    foreach (var item in query) {
                        _tbStock.Rows.Add(new object[] { 
                            item.Id,item.Name,item.SellPrice,item.MensuralUnit.Name
                        });
                    }
                }
                return _tbStock;
            }
            set { _tbStock = value; }
        }
        public DataTable TbDeliveryPerson
        {
            get
            {
                if (_tbDeliveryPerson == null)
                {
                    _tbDeliveryPerson = new DataTable();
                    _tbDeliveryPerson.Columns.Add("Id", typeof(int));
                    _tbDeliveryPerson.Columns.Add("Name");

                    var query = ReceiptManager.GetDeliveryPersons();
                    foreach (var item in query)
                    {
                        _tbDeliveryPerson.Rows.Add(new object[] { item.Id, item.Name });
                    }
                }
                return _tbDeliveryPerson;
            }
            set { _tbDeliveryPerson = value; }
        }
        public DataTable TbAccountClause
        {
            get
            {
                if (_tbAccountClause == null)
                {
                    var query = AccountClauseManager.GetAllWithAccountClauseModel();
                    _tbAccountClause = new DataTable();
                    _tbAccountClause.Columns.Add("Id", typeof(int));
                    _tbAccountClause.Columns.Add("Code");
                    _tbAccountClause.Columns.Add("Description");

                    foreach (var item in query)
                    {
                        _tbAccountClause.Rows.Add(new object[] { item.Id, item.Code, item.Description });
                    }
                }
                return _tbAccountClause;
            }
            set { _tbAccountClause = value; }
        }
        public DataTable TbVatType
        {
            get
            {
                if (_tbVatType == null)
                {
                    _tbVatType = InvoiceManager.GetVatTypeToTable();
                }
                return _tbVatType;
            }
            set { _tbVatType = value; }
        }
        public DataTable TbTax
        {
            get {
                if (_tbTax == null) {
                    _tbTax = new DataTable();
                    _tbTax.Columns.Add("Id", typeof(int));
                    _tbTax.Columns.Add("Percent", typeof(decimal));

                    _tbTax.Rows.Add(new object[] { 1, 1.0 });
                    _tbTax.Rows.Add(new object[] { 2, 2.0 });
                    _tbTax.Rows.Add(new object[] { 3, 3.0 });
                    _tbTax.Rows.Add(new object[] { 4, 4.0 });
                    _tbTax.Rows.Add(new object[] { 5, 5.0 });
                    _tbTax.Rows.Add(new object[] { 6, 6.0 });
                    _tbTax.Rows.Add(new object[] { 7, 7.0 });
                    _tbTax.Rows.Add(new object[] { 8, 8.0 });
                    _tbTax.Rows.Add(new object[] { 9, 9.0 });
                    _tbTax.Rows.Add(new object[] { 10, 10.0 });
                }
                return _tbTax;
            }
            set { _tbTax = value; }
        }
        public DataTable TbDiscount
        {
            get {
                if (_tbDiscount == null)
                {
                    _tbDiscount = new DataTable();
                    _tbDiscount.Columns.Add("Id", typeof(int));
                    _tbDiscount.Columns.Add("Percent", typeof(decimal));

                    _tbDiscount.Rows.Add(new object[] { 1, 1.0 });
                    _tbDiscount.Rows.Add(new object[] { 2, 2.0 });
                    _tbDiscount.Rows.Add(new object[] { 3, 3.0 });
                    _tbDiscount.Rows.Add(new object[] { 4, 4.0 });
                    _tbDiscount.Rows.Add(new object[] { 5, 5.0 });
                    _tbDiscount.Rows.Add(new object[] { 6, 6.0 });
                    _tbDiscount.Rows.Add(new object[] { 7, 7.0 });
                    _tbDiscount.Rows.Add(new object[] { 8, 8.0 });
                    _tbDiscount.Rows.Add(new object[] { 9, 9.0 });
                    _tbDiscount.Rows.Add(new object[] { 10, 10.0 });
                }
                return _tbDiscount;
            }
            set { _tbDiscount = value; }
        }
        public DataTable TbSupplier
        {
            get
            {
                if (_tbSupplier == null)
                {
                    _tbSupplier = new DataTable();
                    _tbSupplier.Columns.Add("Id", typeof(int));
                    _tbSupplier.Columns.Add("Name");
                    _tbSupplier.Columns.Add("Address");


                    var query = MainManager.GetSuppliers();

                    _tbSupplier.Rows.Add(new object[] { 0, "[Chọn đối tượng]", "[Địa chỉ]" });
                    foreach (var item in query)
                    {
                        _tbSupplier.Rows.Add(new object[] { item.Id, item.Name, item.Address });
                    }

                }
                return _tbSupplier;
            }
            set { _tbSupplier = value; }
        }
        #endregion
        public StockInReceiptControl()
        {
            InitializeComponent();
        }
    }
}
