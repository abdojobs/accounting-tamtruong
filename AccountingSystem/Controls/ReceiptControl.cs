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
using Common.Maths;
using AccountingSystem.Utils;
using DataAccess.Entities;
using Business.Models;

namespace AccountingSystem.Controls
{
    public partial class ReceiptControl : UserControl
    {
        IReceiptBusiness _receiptManager;
        IAccountClauseBusiness _accountClauseManager;
        IInvoiceBusiness _invoiceManager;
        ICustomerBusiness _customerManager;
        IAccountBusiness _accountMananger;

        

        

        DataTable _tbVatType;
        DataTable _tbAccountClause;
        DataTable _tbTradingPartner;
        DataTable _tbDeliveryPerson;
        DataTable _tbCustomer;
        DataTable _tbAccount;
        DataTable _tbBalanceAccount;

        #region properties

        public DataTable TbBalanceAccount
        {
            get {
                if (_tbBalanceAccount == null)
                {
                    _tbBalanceAccount = new DataTable();
                    _tbBalanceAccount.Columns.Add("Account_Id", typeof(int));
                    _tbBalanceAccount.Columns.Add("Description");
                    _tbBalanceAccount.Columns.Add("Amount", typeof(int));
                }
                return _tbBalanceAccount;
            }
            set { _tbBalanceAccount = value; }
        }
        public IAccountBusiness AccountMananger
        {
            get {
                if (_accountMananger == null)
                    _accountMananger = new AccountService();
                return _accountMananger;
            }
            set { _accountMananger = value; }
        }
        public DataTable TbAccount
        {
            get {
                if (_tbAccount == null) {
                    _tbAccount = AccountMananger.GetToDataTable();
                }
                return _tbAccount;
            }
            set { _tbAccount = value; }
        }
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
                    _tbDeliveryPerson.Columns.Add("Id",typeof(int));
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
                    _tbTradingPartner.Columns.Add("Id",typeof(int));
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
                    _tbAccountClause.Columns.Add("Id",typeof(int));
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
                    tb.Columns.Add("CustomerId",typeof(int));
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
            DateTime fro = new DateTime(dpMonth.Value.Year,dpMonth.Value.Month,1);
            DateTime to = fro.AddMonths(1);

            string code = txtCodeSearch.Text.Trim();
            gridReceipts.DataSource = ReceiptManager.Search(fro,to, code);
        }
        void LoadAccountClauses()
        {
            cbbAccountClause.ValueMember = "Id";
            cbbAccountClause.DisplayMember = "Code";
            cbbAccountClause.DataSource = TbAccountClause;

            Binding b = new Binding("Text", TbAccountClause, "Description");
            b.NullValue = 0;
            txtAcLDesription.DataBindings.Add(b);

            // init Grid BalanceAccount
            InitBalanceAccountGrid();

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
        void InitBalanceAccountGrid() {
            gridBalanceAccounts.DataSource = TbBalanceAccount;

            gridBalanceAccounts.Columns["Account_Id"].Visible = false;
            // setting columncombobox
            DataGridViewMultiComboboxColumn colCbReceiveAccount = new DataGridViewMultiComboboxColumn();
            colCbReceiveAccount.DataPropertyName = "Account_Id";
            colCbReceiveAccount.HeaderText = "Tài khoản có";
            colCbReceiveAccount.Width = 120;
            colCbReceiveAccount.DataSource = TbAccount;
            colCbReceiveAccount.ValueMember = "Id";
            colCbReceiveAccount.DisplayMember = "Code";
            colCbReceiveAccount.Name = "ReceiveAccount";
            colCbReceiveAccount.ValueType = typeof(int);
            colCbReceiveAccount.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colCbReceiveAccount.FlatStyle = FlatStyle.Flat;
            colCbReceiveAccount.DefaultCellStyle.DataSourceNullValue = -1;
            colCbReceiveAccount.DefaultCellStyle.NullValue = "[Tài khoản có]";
            colCbReceiveAccount.DisplayIndex = 0;
            gridBalanceAccounts.Columns.Add(colCbReceiveAccount);
            colCbReceiveAccount.SetupColumn();
            
        }
        
        void LoadBalanceAccount(int accountClauseId) {

            var query = AccountClauseManager.GetAccountReceivableDetail(accountClauseId);
            TbBalanceAccount.Rows.Clear();
            foreach (var item in query) {
                TbBalanceAccount.Rows.Add(new object[] { item.Account_Id, item.Description });
            }
            
            // get DebtAccount
            var daccount = AccountClauseManager.GetAccountDebtDetail(accountClauseId);
            lbDebtAccount.Text = string.Empty;
            foreach (var item in daccount) {
                lbDebtAccount.Text += UtilGui.ConcatHasHyphen(item.Account.Code);
            }
            if (!string.IsNullOrEmpty(lbDebtAccount.Text))
                lbDebtAccount.Text = lbDebtAccount.Text.Substring(1);
        }

        void LoadInvoices() {
            gridInvoices.EditingControlShowing+=new DataGridViewEditingControlShowingEventHandler(gridInvoices_EditingControlShowing);

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
            vatcol.Name = "VatCol";
            

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
            colCustomer.DisplayIndex = 3;
            
            DataTable tb = new DataTable();
            tb.Columns.Add("Id");
            tb.Columns.Add("Code");
            tb.Columns.Add("DateTax", typeof(DateTime));
            tb.Columns.Add("CustomerId",typeof(int));
            tb.Columns.Add("CustomerName");
            tb.Columns.Add("CustomerAccountNo");
            tb.Columns.Add("Tax");
            tb.Columns.Add("AmountNotTax");
            tb.Columns.Add("AmountHasTax");
            tb.Columns.Add("Note");

            //tb.Rows.Add(new object[] { 6, null, DateTime.Now });
            

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
            gridInvoices.Columns["Id"].Visible = false;

            gridInvoices.Columns["Code"].DefaultCellStyle.NullValue = "[Số hóa đơn]";
            gridInvoices.Columns["Code"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["DateTax"].DefaultCellStyle.NullValue = DateTime.Now.ToString();
            gridInvoices.Columns["DateTax"].DefaultCellStyle.DataSourceNullValue = -1;
            //gridInvoices.Columns["DateTax"].DataPropertyName = "DateTax";
            
            

            gridInvoices.Columns["Tax"].DefaultCellStyle.NullValue = "0";
            gridInvoices.Columns["Tax"].DefaultCellStyle.DataSourceNullValue = -1;
            gridInvoices.Columns["Tax"].ReadOnly = true;

            gridInvoices.Columns["CustomerId"].DefaultCellStyle.NullValue = "[Mã số khách hàng]";
            gridInvoices.Columns["CustomerId"].DefaultCellStyle.DataSourceNullValue = -1;
            gridInvoices.Columns["CustomerId"].Visible = false;

            gridInvoices.Columns["CustomerName"].DefaultCellStyle.NullValue = "[Tên khách hàng]";
            gridInvoices.Columns["CustomerName"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["CustomerAccountNo"].DefaultCellStyle.NullValue = "[Tài khoản NH]";
            gridInvoices.Columns["CustomerAccountNo"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["AmountNotTax"].DefaultCellStyle.NullValue = "0";
            gridInvoices.Columns["AmountNotTax"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["AmountHasTax"].DefaultCellStyle.NullValue = "0";
            gridInvoices.Columns["AmountHasTax"].DefaultCellStyle.DataSourceNullValue = -1;

            gridInvoices.Columns["Note"].DefaultCellStyle.NullValue = "[Ghi chú]";
            gridInvoices.Columns["Note"].DefaultCellStyle.DataSourceNullValue = -1;
        }

        void gridInvoices_EditingControlShowing(object sender,DataGridViewEditingControlShowingEventArgs e) {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null && combo.Name != "VatCol")
            {
                DataGridView grid = sender as DataGridView;
                string colname = grid.Columns[grid.CurrentCell.ColumnIndex].Name;
                combo.Name = colname;
                combo.SelectionChangeCommitted -= new EventHandler(combo_SelectionChangeCommitted);
                combo.SelectionChangeCommitted += new EventHandler(combo_SelectionChangeCommitted);
            }
            TextBox text = e.Control as TextBox;
            if (text != null && text.Name != "TextBox") { 
                text.TextChanged+=new EventHandler(text_TextChanged);
                text.KeyPress+=new KeyPressEventHandler(text_KeyPress);
                text.Validating+=new CancelEventHandler(text_Validating);
                text.Name = "TextBox";
            }
        }
        void text_Validating(object sender, CancelEventArgs e) {
            //TextBox text=sender as TextBox;
            //if (!text.Text.IsDecimal()) {
            //    e.Cancel = true;
            //}
        }
        void text_KeyPress(object sender, KeyPressEventArgs e) {
            string colname = gridInvoices.Columns[gridInvoices.CurrentCell.ColumnIndex].Name;
            if (colname == "AmountNotTax")
                e.Handled = !Common.Maths.ValidateInput.OnlyDecimal(((TextBox)sender).Text, e.KeyChar);
        }
        string textbefore = string.Empty;
        void text_TextChanged(object sender, EventArgs e) {
            TextBox text = sender as TextBox;
            
            string colname = gridInvoices.Columns[gridInvoices.CurrentCell.ColumnIndex].Name;
            if (colname == "AmountNotTax")
            {
                double tax = gridInvoices.CurrentRow.Cells["Tax"].Value.ToDouble();
                decimal amount = gridInvoices.CurrentRow.Cells["AmountNotTax"].EditedFormattedValue.ToDecimal();
                gridInvoices.CurrentRow.Cells["AmountHasTax"].Value = AccountMath.CalculateTax(amount, (double)tax);
            }
        }
        void combo_SelectionChangeCommitted(object sender, EventArgs e) {
            ComboBox combo = sender as ComboBox;
            DataRowView item = combo.SelectedItem as DataRowView;
            string colname = gridInvoices.Columns[gridInvoices.CurrentCell.ColumnIndex].Name;
            if (item != null)
            {
                // execute for tax combobox
                if (colname == "VatCol" || colname=="AccountNotTax")
                {
                    double tax = item.Row["Tax"].ToDouble();
                    decimal amount = gridInvoices.CurrentRow.Cells["AmountNotTax"].Value.ToDecimal();
                    gridInvoices.CurrentRow.Cells["Tax"].Value = tax;
                    gridInvoices.CurrentRow.Cells["AmountHasTax"].Value = AccountMath.CalculateTax(amount, (double)tax);
                }
                else if (colname == "Customer") {
                    //gridInvoices.CurrentRow.Cells["CustomerName"].Value = item.Row["CustomerName"];
                    //gridInvoices.CurrentRow.Cells["CustomerAccountNo"].Value = item.Row["CustomerAccountNo"];
                }
            }

        }
       
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateGuideInput())
                {
                    SaveReceipt();
                }
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
        private ErrorProvider errorprovider=new ErrorProvider();
        bool ValidateGuideInput() { 
            bool iserror = true;
            iserror &= errorprovider.UpdateError(txtCode, ErrorsManager.Error0019, string.IsNullOrEmpty(txtCode.Text.TrimOrEmpty()));
            iserror &= errorprovider.UpdateError(txtCAddress, ErrorsManager.Error0024, cbbCCode.SelectedValue.ToInt() == 0);
            iserror &= errorprovider.UpdateError(txtAcLDesription, ErrorsManager.Error0025, cbbAccountClause.SelectedValue.ToInt() == 0);
            return !iserror;
        }
        List<Invoice> GetInvoices() {
            List<Invoice> list = new List<Invoice>();
            foreach (DataGridViewRow r in gridInvoices.Rows) {
                if (!r.IsNewRow) {
                    Invoice inv = new Invoice();
                    inv.VatType = new VatType();
                    inv.VatType.Id = r.Cells["Id"].Value.ToInt();
                    inv.PerformDate = dpCreateDate.Value;
                    inv.Description = r.Cells["Note"].Value.DBValueToString();
                    inv.Code = r.Cells["Code"].Value.DBValueToString();
                    inv.Amount = r.Cells["AmountHasTax"].Value.ToValue<decimal>() + r.Cells["AmountNotTax"].Value.ToValue<decimal>();
                    inv.Customer = new Customer();
                    inv.Customer.Id = ((DataGridViewComboBoxCell)r.Cells["Customer"]).Value.ToValue<int>();

                    list.Add(inv);
                }
            }
            return list;
        }
        List<BalanceAccountModel> GetBalanceAccounts() {
            List<BalanceAccountModel> list = new List<BalanceAccountModel>();
            foreach (DataGridViewRow r in gridBalanceAccounts.Rows)
            {
                if (!r.IsNewRow)
                {
                    BalanceAccountModel bl = new BalanceAccountModel();
                    bl.Account = new Account();
                    bl.Account.Id = r.Cells["Account_Id"].Value.ToValue<int>();
                    bl.ReceiveAmount = r.Cells["Amount"].Value.ToValue<decimal>();
                    bl.DedtAmount = 0;
                    bl.Description = r.Cells["Description"].Value.DBValueToString();

                    list.Add(bl);
                }
            }
            return list;
        }
        Receipt GetReceipt() {
            Receipt receipt = new Receipt();
            receipt.Code = txtCode.Text.TrimOrEmpty();
            receipt.CreateDate = dpCreateDate.Value;
            receipt.DeliveryPerson = new DeliveryPerson();
            receipt.DeliveryPerson.Id = cbbPersonDelievery.SelectedValue.ToValue<int>();
            receipt.AccountClause = new AccountClause();
            receipt.AccountClause.Id = cbbAccountClause.SelectedValue.ToValue<int>();
            receipt.TradingPartner = new TradingPartner();
            receipt.TradingPartner.Id = cbbCCode.SelectedValue.ToValue<int>();

            return receipt;
        }
        void SaveReceipt() {
            Receipt receipt = GetReceipt();
            List<Invoice> invoices = GetInvoices();
            List<BalanceAccountModel> balances = GetBalanceAccounts();
            ReceiptModel rm = new ReceiptModel();
            rm.BalanceAccounts = balances;
            rm.Invoices = invoices;
            rm.Receipt = receipt;
            rm.TradingPartner = receipt.TradingPartner;
            rm.DeliveryPerson = receipt.DeliveryPerson;
            rm.AccountClause = receipt.AccountClause;

            ReceiptManager.addReceiptProceduce(rm);

            LoadReceipts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReceipts();
        }
    }
}
