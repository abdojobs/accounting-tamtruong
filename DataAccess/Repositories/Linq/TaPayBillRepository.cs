using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Models.Views;
using Common.Logs;
using System.Data.Entity;
using System.Data;

namespace DataAccess.Repositories.Linq
{
    public class TaPayBillRepository:TaDataContextEntity<PayBill>,ITaPayBillRepository
    {

        public List<PayBillView> Search(DateTime to, DateTime fro, string code)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    var query = Context.PayBills
                        .Where(r => r.CreateDate >= fro && r.CreateDate <= to && (r.Code.Contains(code) || string.IsNullOrEmpty(code)))
                        .AsNoTracking().Select(
                            r => new PayBillView()
                            {
                                Id = r.Id,
                                Code = r.Code,
                                CreateDate = r.CreateDate,
                                Amount = r.Amount,
                                Receiver=r.Receiver.Name,
                                Supplier=r.Supplier.Name
                            }); ;
                    return query.ToList();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }

                return null;
            }
        }

        public PayBill AddPayBill(PayBill paybill, int receiver_id, int supplier_id, int accountclause_id)
        {
            using (var Context = new TaDalContext())
            {
                try
                {

                    // set supplier for receipt
                    paybill.Supplier = Context.Suppliers.Find(supplier_id);
                    // set DeliveryPerson for receipt
                    paybill.Receiver = Context.Receivers.Find(receiver_id);
                    // set AccountClause for receipt
                    paybill.AccountClause = Context.AccountClauses.Find(accountclause_id);
                    //receipt.AccountClause_Id = receiptmodel.AccountClause.Id;

                    //save
                    Context.PayBills.Add(paybill);
                    Context.SaveChanges();

                    return paybill;
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }



        public void AddInvoicePayBills(List<Invoice_PayBill> invoices)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    foreach (var item in invoices)
                    {
                        Invoice_PayBill i = new Invoice_PayBill()
                        {
                            Invoice_Id = item.Invoice.Id,
                            PayBill_Id = item.PayBill.Id
                        };
                        Context.Invoice_PayBills.Add(i);

                    }
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }


        public void UpdateAmount(int paybill_id, decimal amount)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    PayBill paybill = Context.PayBills.Find(paybill_id);
                    paybill.Amount = amount;

                    // update Debt Account
                    string acTypeCode = AccountTypeEnum.C.ToString();
                    int accountTypeId = Context.AccountTypes.Where(t => t.Code == acTypeCode).Select(t => t.Id).FirstOrDefault();
                    AccountClauseDetail acDetail = Context.AccountClauseDetails.Where(d => d.AccountClause_Id == paybill.AccountClause.Id && d.AccountType_Id == accountTypeId).FirstOrDefault();
                    string pTypeCode = EProceduceType.R.ToString();
                    ProceduceType ptype = Context.ProceduceTypes.Where(p => p.Code == pTypeCode).FirstOrDefault();
                    if (acDetail != null && ptype != null)
                    {
                        // save Debt Account amount into GeneralJournal

                        GeneralJournal gj = new GeneralJournal()
                        {
                            Account_Id = acDetail.Account_Id,
                            Proceduce_Id = paybill.Id,
                            Proceducetype_Id = ptype.Id,
                            Description = paybill.AccountClause.Description,
                            ReceiveAmount = amount,
                            DebtAmount = 0
                        };

                        Context.GeneralJournals.Add(gj);
                    }

                    //update paybill
                    Context.PayBills.Attach(paybill);
                    Context.Entry(paybill).State = EntityState.Modified;
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }


        public void WriteGeneralJournal(int paybill_id, int proceducetype_id, List<GeneralJournal> gens)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    foreach (var item in gens)
                    {
                        item.Proceduce_Id = paybill_id;
                        item.Proceducetype_Id = proceducetype_id;

                        Context.GeneralJournals.Add(item);
                    }
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }
    }
}
