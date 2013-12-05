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
using AccountingSystem.Components;

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
        DataTable _tbWareHouse;

        

        IMainBusiness _mainManager;
        IReceiptBusiness _receiptManager;
        IAccountClauseBusiness _accountClauseManager;
        IInvoiceBusiness _invoiceManager;

        #endregion

        

        #region Properties

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
            get
            {
                if (_mainManager == null)
                {
                    _mainManager = new MainService();
                }
                return _mainManager;
            }
            set { _mainManager = value; }
        }
        #endregion

        public DataTable TbWareHouse
        {
            get {
                if (_tbWareHouse == null) {
                    _tbWareHouse = new DataTable();
                    _tbWareHouse.Columns.Add("Id",typeof(int));
                    _tbWareHouse.Columns.Add("Name");
                    _tbWareHouse.Columns.Add("Address");

                    var query=MainManager.GetWareHouse();
                    foreach (var item in query) {
                        _tbWareHouse.Rows.Add(new object[]{item.Id,item.Name,item.Address});
                    }
                    
                }
                return _tbWareHouse;
            }
            set { _tbWareHouse = value; }
        }

        public DataTable TbStock
        {
            get {
                if (_tbStock == null) {
                    _tbStock = new DataTable();
                    _tbStock.Columns.Add("Id",typeof(int));
                    _tbStock.Columns.Add("Code");
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
                    _tbSupplier.Columns.Add("AccountNo");
                    _tbSupplier.Columns.Add("Address");


                    var query = MainManager.GetSuppliers();

                    _tbSupplier.Rows.Add(new object[] { 0, "[Chọn đối tượng]","[Tài khoản ngân hàng]", "[Địa chỉ]" });
                    foreach (var item in query)
                    {
                        _tbSupplier.Rows.Add(new object[] { item.Id, item.Name,item.BankAccountNo, item.Address });
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
            LoadDeliveryPerson();
            LoadAccountClause();
            LoadSupplier();
            LoadWareHouse();
            LoadTax_VatType_Discount();
            LoadGridStock();
        }

        #region Binding for Control
        void LoadDeliveryPerson() {
            cbbDeliveryPerson.ValueMember = "Id";
            cbbDeliveryPerson.DisplayMember = "Name";
            cbbDeliveryPerson.DataSource = TbDeliveryPerson;
        }
        void LoadAccountClause() {
            cbbAccountClause.DisplayMember = "Code";
            cbbAccountClause.ValueMember = "Id";
            cbbAccountClause.DataSource = TbAccountClause;

            Binding b = new Binding("Text", TbAccountClause, "Description");
            b.NullValue = 0;
            txtALDesription.DataBindings.Add(b);
        }
        void LoadSupplier() {
            cbbSupplier.ValueMember = "Id";
            cbbSupplier.DisplayMember = "Name";
            cbbSupplier.DataSource = TbSupplier;

            Binding b = new Binding("Text", TbSupplier, "Name");
            b.NullValue = 0;
            txtSupplierName.DataBindings.Add(b);

            Binding b1 = new Binding("Text", TbSupplier, "AccountNo");
            b.NullValue = 0;
            txtSupplierAccountNo.DataBindings.Add(b1);

            Binding b2 = new Binding("Text", TbSupplier, "Address");
            b.NullValue = 0;
            txtSupplierAddress.DataBindings.Add(b2);
        }
        void LoadWareHouse() {
            cbbWareHouse.ValueMember = "Id";
            cbbWareHouse.DisplayMember = "Name";
            cbbWareHouse.DataSource = TbWareHouse;

            Binding b = new Binding("Text", TbWareHouse, "Name");
            b.NullValue = 0;
            txtWareHouse.DataBindings.Add(b);
        }
        void LoadTax_VatType_Discount() {
            cbbTax.ValueMember = "Id";
            cbbTax.DisplayMember = "Percent";
            cbbTax.DataSource = TbTax;

            cbbVatType.ValueMember = "Id";
            cbbVatType.DisplayMember = "Code";
            cbbVatType.DataSource = TbVatType;

            cbbDiscount.ValueMember = "Id";
            cbbDiscount.DisplayMember = "Percent";
            cbbDiscount.DataSource = TbDiscount;
        }

        void LoadGridStock() {
            DataGridViewMultiComboboxColumn stockCol = new DataGridViewMultiComboboxColumn();
            stockCol.DataPropertyName = "Id";
            stockCol.HeaderText = "Mã VT";
            stockCol.Width = 120;
            stockCol.DataSource = TbStock;
            stockCol.ValueMember = "Id";
            stockCol.ValueType=typeof(int);
            stockCol.DisplayMember = "Code";
            stockCol.Name = "VatType";
            stockCol.ValueType = typeof(int);
            stockCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            stockCol.FlatStyle = FlatStyle.Flat;
            stockCol.DefaultCellStyle.DataSourceNullValue = -1;
            stockCol.DefaultCellStyle.NullValue = "[Mã vật tư]";
            stockCol.DisplayIndex = 0;
            stockCol.Name = "stockCol";
            stockCol.DisplayIndex = 0;

            DataTable tb = new DataTable();
            tb.Columns.Add("Id");
            tb.Columns.Add("Name");
            tb.Columns.Add("SellPrice");
            tb.Columns.Add("Quantity");
            tb.Columns.Add("MensuralUnit");
            tb.Columns.Add("Amount");

            gridStock.DataSource = tb;

            gridStock.Columns["Id"].DefaultCellStyle.NullValue = "0";
            gridStock.Columns["Id"].DefaultCellStyle.DataSourceNullValue = -1;
            gridStock.Columns["Id"].Visible = false;

            gridStock.Columns["Name"].DefaultCellStyle.NullValue = "[Tên vật tư]";
            gridStock.Columns["Name"].DefaultCellStyle.DataSourceNullValue = -1;
            gridStock.Columns["Name"].HeaderText = "Tên vật tư";

            gridStock.Columns["MensuralUnit"].DefaultCellStyle.NullValue = "[Đơn vị]";
            gridStock.Columns["MensuralUnit"].DefaultCellStyle.DataSourceNullValue = -1;
            gridStock.Columns["MensuralUnit"].HeaderText = "Đơn vị";

            gridStock.Columns["Quantity"].DefaultCellStyle.NullValue = "[Số lượng]";
            gridStock.Columns["Quantity"].DefaultCellStyle.DataSourceNullValue = -1;
            gridStock.Columns["Quantity"].HeaderText = "Số lượng";

            gridStock.Columns["SellPrice"].DefaultCellStyle.NullValue = "[Đơn giá]";
            gridStock.Columns["SellPrice"].DefaultCellStyle.DataSourceNullValue = -1;
            gridStock.Columns["SellPrice"].HeaderText = "Đơn giá";

            gridStock.Columns["Amount"].DefaultCellStyle.NullValue = "[Tiền]";
            gridStock.Columns["Amount"].DefaultCellStyle.DataSourceNullValue = -1;
            gridStock.Columns["Amount"].HeaderText = "Tiền";

            gridStock.Columns.Add(stockCol);
            stockCol.SetupColumn();
        }
        #endregion
    }
}
