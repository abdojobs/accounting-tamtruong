using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Business.Business.ServiceInterfaces;
using Business.Business;
using DataAccess.Entities;
using DataAccess.Repositories.Linq;
using System.Transactions;

namespace Unitest
{
    [TestFixture]
    public class EFTest
    {
        IReceiptBusiness receiptManager;
        [SetUp]
        protected void SetUp()
        {
            receiptManager = new ReceiptService();
        }

        [Test]
        public void AddReceipt() {
            Receipt receipt = new Receipt();
            receipt.Code = "PT0010";
            receipt.CreateDate = DateTime.Now;
           
            receipt.Amount = 1000;

            using (var Context = new TaDalContext()) {
                receipt.AccountClause = Context.AccountClauses.Find(1);
                receipt.DeliveryPerson = Context.DeliveryPersons.Find(1);
                receipt.TradingPartner = Context.TradingPartners.Find(1);

                Context.Receipts.Add(receipt);
                Context.SaveChanges();
            }
        }
        [Test]
        public void AddEntityAndGetId() { 
            using(var Context =new TaDalContext()){
                
                Account account = new Account() { 
                    Code="444",
                    Description="444"
                };
                Context.Accounts.Add(account);
                Context.SaveChanges();
                int rs = account.Id;

                Assert.IsTrue(rs != 0);
            }
        }
        [Test]
        public void AddMultiEntityInTransaction() {
            using (TransactionScope transactionScope = new TransactionScope()) {
                using (var Context = new TaDalContext()) {
                    Account account = new Account()
                    {
                        Code = "555",
                        Description = "555"
                    };

                    Account account1 = new Account()
                    {
                        Code = "666",
                        Description = "666"
                    };

                    Context.Accounts.Add(account);
                    Context.SaveChanges();
                    int rs = account.Id;

                    Assert.IsTrue(rs != 0);

                    Context.Accounts.Add(account1);
                    Context.SaveChanges();
                    rs = account.Id;

                    Assert.IsTrue(rs != 0);
                }
            }
        }
    }
}
