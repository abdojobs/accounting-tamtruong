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
using Common.Exceptions;
using Common.Logs;
using Common.Messages;
using AccountBusiness.Business.ServiceInterfaces;
using AccountBusiness.Business;
using AccountingSystem.Components;

namespace AccountingSystem.Controls
{
    public partial class ReceiptControl : UserControl
    {
        IReceiptBusiness _receiptManager;
        IAccountClauseBusiness _accountClauseManager;
        IInvoiceBusiness _invoiceManager;
        ICustomerBusiness _customerManager;

        

        DataTable _tbVatType;

       
        DataTable _tbAccountClause;
        DataTable _tbTradingPartner;
        DataTable _tbDeliveryPerson;
        DataTable _tbCustomer;

        
        

        

        #region properties
        public DataTable TbVatType
        {
            get {
                if (_tbVatType == null) {
                    _tbVatType = InvoiceManager.GetVatTypeToTable();
                }
                return _tbVatType;
            }
            set { _tbVatType = value; }
        }
        public IInvoiceBusiness InvoiceManager
        {
            get {
                if (_invoiceManager == null)
                {
                    _invoiceManager = new InvoiceService();
                }
                return _invoiceManager;
            }
            set { _invoiceManager = value; }
        }
        public DataTable TbDeliveryPerson
        {
            get
            {
                if (_tbDeliveryPerson == null)
                {
                    _tbDeliveryPerson = new DataTable();
                    _tbDeliveryPerson.Columns.Add("Id");
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
        public DataTable TbTradingPartner
        {
            get {
                if (_tbTradingPartner == null) {
                    _tbTradingPartner = new DataTable();
                    _tbTradingPartner.Columns.Add("Id");
                    _tbTradingPartner.Columns.Add("Name");
                    _tbTradingPartner.Columns.Add("Address");


                    var query = ReceiptManager.GetTradingPartners();

                    _tbTradingPartner.Rows.Add(new object[]{0,"[Chọn đối tượng]","[Địa chỉ]"});
                    foreach (var item in query) {
                        _tbTradingPartner.Rows.Add(new object[] { item.Id,item.Name,item.Address});
                    }
                    
                }
                return _tbTradingPartner;
            }
            set { _tbTradingPartner = value; }
        }
        public DataTable TbAccountClause
        {
            get
            {
                if (_tbAccountClause == null)
                {
                    var query = AccountClauseManager.GetAllWithAccountClauseModel();
                    _tbAccountClause = new DataTable();
                    _tbAccountClause.Columns.Add("Id");
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
        public DataTable TbCustomer
        {
            get {
                if (_tbCustomer == null) {
                    DataTable tb = new DataTable();
                    tb.Columns.Add("CustomerId");
                    tb.Columns.Add("CustomerName");
                    tb.Columns.Add("CustomerAccountNo");
                    var query = CustomerManager.GetAll();
                    foreach (var item in query) {
                        tb.Rows.Add(new object[] { item.Id, item.Name, item.BankAccountNo });
                    }
                    _tbCustomer = tb; 
                }
                return _tbCustomer;
            }
            set { _tbCustomer = value; }
        }
        public ICustomerBusiness CustomerManager
        {
            get {
                if (_customerManager == null)
                    _customerManager = new CustomerService();
                return _customerManager;
            }
            set { _customerManager = value; }
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
        #endregion

        #region methods


        public ReceiptControl()
        {
            try
            {
                InitializeComponent();
                LoadReceipts();
                LoadAccountClauses();
                LoadTradingPartners();
                LoadDeliveryPersons();
                LoadInvoices();

            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
                WriteLog.Warnning(this.GetType(), ex);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
            }
            
        }
        void LoadReceipts()
        {
            DateTime current = DateTime.Now;
            DateTime from = new DateTime(current.Year, current.Month, 1);
            DateTime to = DateTime.Now;

            gridReceipts.DataSource = ReceiptManager.Search(to, from, string.Empty);
        }
        void LoadAccountClauses()
        {
            cbbAccountClause.ValueMember = "Id";
            cbbAccountClause.DisplayMember = "Code";
            cbbAccountClause.DataSource = TbAccountClause;

            Binding b = new Binding("Text", TbAccountClause, "Description");
            b.NullValue = 0;
            txtAcLDesription.DataBindings.Add(b);

            cbbAccountClause.SelectedIndexChanged+=new EventHandler(cbbAccountClause_SelectedIndexChanged);
        }
        void cbbAccountClause_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox combo = sender as ComboBox;
            int accountClauseId = Convert.ToInt32(combo.SelectedValue);

            LoadBalanceAccount(accountClauseId);
        }
        void LoadTradingPartners()
        {
            cbbCCode.DataSource = TbTradingPartner;
            cbbCCode.DisplayMember = "Id";
            cbbCCode.ValueMember = "Id";

            cbbCName.DataSource = TbTradingPartner;
            cbbCName.DisplayMember = "Name";
            cbbCName.ValueMember = "Id";

            Binding b = new Binding("Text", TbTradingPartner, "Address");
            b.NullValue = 0;
            //b.DataSourceNullValue = "Địa chỉ";
            txtCAddress.DataBindings.Add(b);
        }

        void LoadDeliveryPersons()
        {
            cbbPersonDelievery.DataSource = TbDeliveryPerson;
            cbbPersonDelievery.DisplayMember = "Name";
            cbbPersonDelievery.ValueMember = "Id";

            
        }
        void LoadBalanceAccount(int accountClauseId) {
            DataTable tb = new DataTable();
            tb.Columns.Add("Account_Id");
            tb.Columns.Add("Description");
            tb.Columns.Add("Amount",typeof(int));

            var query = AccountClauseManager.GetAccountReceivableDetail(accountClauseId);
            foreach (var item in query) {
                tb.Rows.Add(new object[] { item.Account_Id,item.Description});
            }
            gridBalanceAccounts.DataSource = tb;
        }

        void LoadInvoices() {
            DataGridViewComboBoxColumn vatcol = new DataGridViewComboBoxColumn();
            vatcol.DataPropertyName = "Id";
            vatcol.HeaderText = "01/2GTGT";
            vatcol.Width = 120;
            vatcol.DataSource = TbVatType;
            vatcol.ValueMember = "Id";
            vatcol.DisplayMember = "Code";
            vatcol.Name = "VatType";
            vatcol.ValueType = typeof(int);
            vatcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            vatcol.FlatStyle = FlatStyle.Flat;
            vatcol.DefaultCellStyle.DataSourceNullValue = -1;
            vatcol.DefaultCellStyle.NullValue = "[Hóa đơn]";
            vatcol.DisplayIndex = 0;

            DataGridViewMultiComboboxColumn colCustomer = new DataGridViewMultiComboboxColumn();
            colCustomer.DataPropertyName = "CustomerId";
            colCustomer.HeaderText = "Khách hàng";
            colCustomer.Width = 120;
            colCustomer.DataSource = TbCustomer;
            colCustomer.ValueMember = "CustomerId";
            colCustomer.DisplayMember = "CustomerName";
            colCustomer.Name = "Customer";
            colCustomer.ValueType = typeof(int);
            colCustomer.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colCustomer.FlatStyle = FlatStyle.Flat;
            colCustomer.DefaultCellStyle.DataSourceNullValue = -1;
            colCustomer.DefaultCellStyle.NullValue = "[Khách hàng]";
            colCustomer.DisplayIndex = 0;
            
            DataTable tb = new DataTable();
            tb.Columns.Add("Id");
            tb.Columns.Add("Code");
            tb.Columns.Add("DateTax", typeof(DateTime));
            tb.Columns.Add("CustomerId");
            tb.Columns.Add("CustomerName");
            tb.Columns.Add("CustomerAccountNo");
            tb.Columns.Add("Tax");
            tb.Columns.Add("AmountNotTax");
            tb.Columns.Add("AmountHasTax");
            tb.Columns.Add("Note");

            tb.Rows.Add(new object[] { 6, null, DateTime.Now });
            

            CalendarColumn calcol = new CalendarColumn();
            calcol.Name = "DateTax";
            ((DataGridViewColumn)calcol).DataPropertyName = "DateTax";
            

            gridInvoices.Columns.Add(calcol);

            gridInvoices.DataSource = tb;

            gridInvoices.Columns.Add(vatcol);
            gridInvoices.Columns.Add(colCustomer);
            colCustomer.SetupColumn();

            gridInvoices.Columns["Id"].DefaultCellStyle.NullValue = "[Số hóa đơn]";
            gridInvoices.Columns["Id"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["Code"].DefaultCellStyle.NullValue = "[Số hóa đơn]";
            gridInvoices.Columns["Code"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["DateTax"].DefaultCellStyle.NullValue = DateTime.Now.ToString();
            gridInvoices.Columns["DateTax"].DefaultCellStyle.DataSourceNullValue = -1;
            //gridInvoices.Columns["DateTax"].DataPropertyName = "DateTax";
            
            

            gridInvoices.Columns["Tax"].DefaultCellStyle.NullValue = "[Thuế]";
            gridInvoices.Columns["Tax"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["CustomerId"].DefaultCellStyle.NullValue = "[Mã số khách hàng]";
            gridInvoices.Columns["CustomerId"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["CustomerName"].DefaultCellStyle.NullValue = "[Tên khách hàng]";
            gridInvoices.Columns["CustomerName"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["CustomerAccountNo"].DefaultCellStyle.NullValue = "[Tài khoản NH]";
            gridInvoices.Columns["CustomerAccountNo"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["AmountNotTax"].DefaultCellStyle.NullValue = "[Tiền chưa thuế]";
            gridInvoices.Columns["AmountNotTax"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["AmountHasTax"].DefaultCellStyle.NullValue = "[Tiền thuế]";
            gridInvoices.Columns["AmountHasTax"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["Note"].DefaultCellStyle.NullValue = "[Ghi chú]";
            gridInvoices.Columns["Note"].DefaultCellStyle.DataSourceNullValue = -1;
        }
        #endregion
        
    }
}
