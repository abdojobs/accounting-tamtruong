using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Business.Business.ServiceInterfaces;
using Business.Business;
using DataAccess.Entities;
using Business.Models;

namespace Unitest
{
    [TestFixture]
    public class PayBillTest
    {
        IPayBillBusiness paybillManager;
        [SetUp]
        protected void SetUp()
        {
            paybillManager = new PayBillService();
        }

        [Test]
        public void AddPayBillProceduce() {
            PayBill paybill = new PayBill();
            paybill.Code = "PC0001";
            paybill.CreateDate = DateTime.Now;

            List<BalanceAccountModel> balances = new List<BalanceAccountModel>() { 
                new BalanceAccountModel(){
                    Account=new Account(){Id=13},
                    ReceiveAmount=500,
                    DedtAmount=0,
                    Description="tra tien khach hang"
                },
                new BalanceAccountModel(){
                    Account=new Account(){Id=14},
                    ReceiveAmount=1500,
                    DedtAmount=0,
                    Description="tra tien khach hang"
                },
                new BalanceAccountModel(){
                    Account=new Account(){Id=15},
                    ReceiveAmount=4000,
                    DedtAmount=0,
                    Description="tra tien khach hang"
                }
            };

            List<Invoice> invoices = new List<Invoice>() { 
                new Invoice(){
                    Code="inv0004",
                    Amount=1000,
                    PerformDate=DateTime.Now,
                    VatType=new VatType(){Id=5},
                    Customer=new Customer(){Id=2},
                    Description="thanh toan cho inv0004"
                },
                new Invoice(){
                    Code="inv0005",
                    Amount=2000,
                    PerformDate=DateTime.Now,
                    VatType=new VatType(){Id=6},
                    Customer=new Customer(){Id=2},
                    Description="thanh toan cho inv0005"
                },
                new Invoice(){
                    Code="inv0006",
                    Amount=3000,
                    PerformDate=DateTime.Now,
                    VatType=new VatType(){Id=5},
                    Customer=new Customer(){Id=2},
                    Description="thanh toan cho inv0006"
                }
            };

            PayBillModel pm = new PayBillModel();
            pm.PayBill = paybill;
            pm.BalanceAccounts = balances;
            pm.Invoices = invoices;
            pm.Supplier = new Supplier() { Id = 10 };
            pm.Receiver = new Receiver() { Id = 2 };
            pm.AccountClause = new AccountClause() { Id = 6 };
            pm.PayBill.Receiver = pm.Receiver;
            pm.PayBill.Supplier = pm.Supplier;
            pm.PayBill.AccountClause = pm.AccountClause;

            paybillManager.addPayBillProceduce(pm);
        }
    }
}
