using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Business.Business.ServiceInterfaces;
using Business.Business;
using DataAccess.Entities;
using Business.Models;
using AccountBusiness.Models.Views;

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

            List<BalanceAccountModel> balances = new List<BalanceAccountModel>() { 
                new BalanceAccountModel(){
                    Account=new Account(){Id=23},
                    ReceiveAmount=500,
                    DedtAmount=0,
                    Description="thu tien khach hang"
                },
                new BalanceAccountModel(){
                    Account=new Account(){Id=24},
                    ReceiveAmount=1500,
                    DedtAmount=0,
                    Description="thu tien khach hang"
                },
                new BalanceAccountModel(){
                    Account=new Account(){Id=25},
                    ReceiveAmount=4000,
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
        }

        [Test]
        public void SearchReceipt() {
            DateTime to = DateTime.Now;
            DateTime fro = to.AddMonths(-1);
            IList<ReceiptView> list = receiptManager.Search(to,fro,string.Empty);

            Assert.IsNotNull(list);
        }
    }
}
