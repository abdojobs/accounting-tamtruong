using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;
using Common.Exceptions;
using Common.Messages;
using System.Data;
using System.Data.Entity;
using DataAccess.Models.Views;

namespace DataAccess.Repositories.Linq
{
    public class TaReceiptRepository : TaDataContextEntity<Receipt>,ITaReceiptRepository
    {

        public Receipt AddReceipt(Receipt receipt, int tradingpartner_id, int deliveryperson_id, int accountclause_id)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    
                    // set tradingpartner for receipt
                    receipt.TradingPartner = Context.TradingPartners.Find(tradingpartner_id);
                    // set DeliveryPerson for receipt
                    receipt.DeliveryPerson = Context.DeliveryPersons.Find(deliveryperson_id);
                    // set AccountClause for receipt
                    receipt.AccountClause = Context.AccountClauses.Find(accountclause_id);
                    //receipt.AccountClause_Id = receiptmodel.AccountClause.Id;
                    
                    //save
                    Context.Receipts.Add(receipt);
                    Context.SaveChanges();

                    return receipt;
                }
                catch(Exception ex) {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public void AddInvoiceReceipts(List<Invoice_Receipt> invoices)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    foreach (var item in invoices) {
                        Invoice_Receipt i = new Invoice_Receipt() { 
                            Invoice_Id=item.Invoice.Id,
                            Receipt_Id=item.Receipt.Id
                        };
                        Context.Invoice_Receipts.Add(i);
                        
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


        public void WriteGeneralJournal(int receipt_id, int proceducetype_id, List<GeneralJournal> gens)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    foreach (var item in gens)
                    {
                        item.Proceduce_Id=receipt_id;
                        item.Proceducetype_Id=proceducetype_id;

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


        public void UpdateAmount(int id, decimal amount)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    Receipt receipt = Context.Receipts.Find(id);
                    receipt.Amount = amount;

                    // update Debt Account
                    string acTypeCode = AccountTypeEnum.N.ToString();
                    int accountTypeId = Context.AccountTypes.Where(t => t.Code == acTypeCode).Select(t => t.Id).FirstOrDefault();
                    AccountClauseDetail acDetail = Context.AccountClauseDetails.Where(d => d.AccountClause_Id==receipt.AccountClause.Id && d.AccountType_Id==accountTypeId).FirstOrDefault();
                    string pTypeCode=EProceduceType.R.ToString();
                    ProceduceType ptype=Context.ProceduceTypes.Where(p=>p.Code==pTypeCode).FirstOrDefault();
                    if (acDetail != null && ptype!=null) { 
                        // save Debt Account amount into GeneralJournal
                        
                        GeneralJournal gj = new GeneralJournal() { 
                            Account_Id=acDetail.Account_Id,
                            Proceduce_Id=receipt.Id,
                            Proceducetype_Id=ptype.Id,
                            Description=receipt.AccountClause.Description,
                            ReceiveAmount=0,
                            DebtAmount=amount
                        };

                        Context.GeneralJournals.Add(gj);
                    }

                    //update receipt
                    Context.Receipts.Attach(receipt);
                    Context.Entry(receipt).State = EntityState.Modified;
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


        public List<ReceiptView> Search(DateTime to, DateTime fro, string code)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    var query = Context.Receipts
                        .Where(r => r.CreateDate >= fro && r.CreateDate <= to && (r.Code.Contains(code) || string.IsNullOrEmpty(code)))
                        .AsNoTracking().Select(
                            r => new ReceiptView()
                            {
                                Id = r.Id,
                                Code = r.Code,
                                CreateDate = r.CreateDate,
                                TradingPartner = r.TradingPartner.Name,
                                Amount = r.Amount,
                                DeliveryPerson = r.DeliveryPerson.Name,
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
    }
}
