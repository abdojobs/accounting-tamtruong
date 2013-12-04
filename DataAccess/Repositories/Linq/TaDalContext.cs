using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Entities;
using System.Data;

namespace DataAccess.Repositories.Linq
{
    public class TaDalContext : DbContext
    {
        /// <summary> 
        /// This method is called when the model for a derived context has been initialized, but  
        /// before the model has been locked down and used to initialize the context.  
        /// </summary> 
        /// <param name="modelBuilder">It is used to map CLR classes to a database schema. </param> 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  Disable the default PluralizingTableNameConvention 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new TaDbGenerator<TaDalContext>());
            base.OnModelCreating(modelBuilder);
        }
        public TaDalContext(string DBConnecstring)
            : base(DBConnecstring)
        { 
            
        }
        public TaDalContext():base(GlobalConstant.DBConnecstring) { 
            
        }
        public void Update<T>(T entity) where T:class {
            this.Set<T>().Attach(entity);
            this.Entry(entity).State = EntityState.Modified;
        }
        #region DataContext To Database
        public DbSet<Account> Accounts { get;set; }
        public DbSet<AccountClause> AccountClauses { get;set; }
        public DbSet<AccountClauseDetail> AccountClauseDetails { get;set; }
        public DbSet<AccountType> AccountTypes { get;set; }

        public DbSet<Customer> Customers { get;set; }
        public DbSet<Decree> Decrees { get;set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get;set; }
        public DbSet<Invoice> Invoices { get;set; }
        public DbSet<Invoice_PayBill> Invoice_PayBills { get;set; }
        public DbSet<Invoice_Receipt> Invoice_Receipts { get;set; }
        public DbSet<Invoice_StockInReceipt> Invoice_StockInReceipts { get;set; }
        public DbSet<Invoice_StockOutReceipt> Invoice_StockOutReceipt { get;set; }

        public DbSet<MensuralUnit> MensuralUnits { get;set; }
        public DbSet<PayBill> PayBills { get;set; }
        public DbSet<Person> Persons { get;set; }
        public DbSet<Receipt> Receipts { get;set; }
        public DbSet<Receiver> Receivers { get;set; }
        public DbSet<Stock> Stocks { get;set; }

        public DbSet<StockInDetail> StockInDetails { get;set; }
        public DbSet<StockInReceipt> StockInReceipts { get;set; }
        public DbSet<StockOutReceipt> StockOutReceipts { get;set; }
        public DbSet<StockOutDetail> StockOutDetails { get;set; }
        public DbSet<Supplier> Suppliers { get;set; }
        public DbSet<TradingPartner> TradingPartners { get;set; }
        public DbSet<VatType> VatTypes { get;set; }
        public DbSet<WareHouse> WareHouses { get;set; }
        public DbSet<GeneralJournal> GeneralJournals { get; set; }
        public DbSet<ProceduceType> ProceduceTypes { get; set; }
        #endregion
    }
}
