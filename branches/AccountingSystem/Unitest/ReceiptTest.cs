using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Business.Business.ServiceInterfaces;
using Business.Business;
using DataAccess.Entities;
using Business.Models;
using DataAccess.Repositories.Linq;

namespace Unitest
{
    [TestFixture]
    public class ReceiptTest
    {
        IReceiptBusiness receiptManager;
        [SetUp]
        protected void SetUp() {
            receiptManager = new ReceiptService();
        }
        [Test]
        public void AddReceiptProceduce(){
            Receipt receipt = new Receipt();
            receipt.Code = "PT0001";
            receipt.CreateDate = DateTime.Now;
            /* auto delete data had in DB*/
            //first delete data GeneralJournal have receipt.code=PT0001
            //delete invoice_receipt and invoice have codes inv0001,inv0002,inv0003 and receipt.code=PT0001
            //delete receipt have code=PT0001
            using (var Context = new TaDalContext()) {
                try { 
                    
                    Receipt delreceipt = Context.Receipts.Where(r => r.Code == "PT0001").FirstOrDefault();
                    string ptypeCode = EProceduceType.R.ToString();
                    ProceduceType ptype = Context.ProceduceTypes.Where(p => p.Code == ptypeCode).FirstOrDefault();
                    if (delreceipt != null && ptype!=null)
                    {
                        //delete GeneralJournal
                        var gjs = Context.GeneralJournals.Where(g => g.Proceduce_Id == delreceipt.Id && g.Proceducetype_Id==ptype.Id);
                        foreach (var gj in gjs) {
                            Context.GeneralJournals.Remove(gj);
                        }

                        //delete invoice and delete invoice_receipt because relationship foreign key
                        string[] invsCode=new string[]{"inv0001","inv0002","inv0003"};
                        var invs = Context.Invoices.Where(i => invsCode.Contains(i.Code));
                        foreach (var i in invs) {
                            Context.Invoices.Remove(i);
                        }

                        //delete receipt
                        Context.Receipts.Remove(delreceipt);
                    }
                    Context.SaveChanges();
                }
                catch { }
                finally {
                    Context.Dispose();
                }
            }
            List<BalanceAccountModel> balances = new List<BalanceAccountModel>() { 
                new BalanceAccountModel(){
                    Account=new Account(){Id=23},
                    ReceiveAmount=10,
                    DedtAmount=0,
                    Description="thu tien khach hang"
                },
                new BalanceAccountModel(){
                    Account=new Account(){Id=24},
                    ReceiveAmount=20,
                    DedtAmount=0,
                    Description="thu tien khach hang"
                },
                new BalanceAccountModel(){
                    Account=new Account(){Id=25},
                    ReceiveAmount=30,
                    DedtAmount=0,
                    Description="thu tien khach hang"
                }
            };

            List<Invoice> invoices = new List<Invoice>() { 
                new Invoice(){
                    Code="inv0001",
                    Amount=1000,
                    PerformDate=DateTime.Now,
                    VatType=new VatType(){Id=5},
                    Customer=new Customer(){Id=2},
                    Description="thanh toan cho inv0001"
                },
                new Invoice(){
                    Code="inv0002",
                    Amount=2000,
                    PerformDate=DateTime.Now,
                    VatType=new VatType(){Id=6},
                    Customer=new Customer(){Id=2},
                    Description="thanh toan cho inv0002"
                },
                new Invoice(){
                    Code="inv0003",
                    Amount=3000,
                    PerformDate=DateTime.Now,
                    VatType=new VatType(){Id=5},
                    Customer=new Customer(){Id=2},
                    Description="thanh toan cho inv0003"
                }
            };

            ReceiptModel rm = new ReceiptModel();
            rm.Receipt = receipt;
            rm.BalanceAccounts = balances;
            rm.Invoices = invoices;
            rm.TradingPartner = new TradingPartner() { Id = 1 };
            rm.DeliveryPerson = new DeliveryPerson() { Id = 1 };
            rm.AccountClause = new AccountClause() { Id=7};

            receiptManager.addReceiptProceduce(rm);

            // check balance account amount is valid
            int ptypeid=receiptManager.GetReceiptProceduceType();
            bool rs= receiptManager.IsValidBalanceAccountAmount(receipt.Id, ptypeid);

            Assert.IsTrue(rs);
        }
    }
}
