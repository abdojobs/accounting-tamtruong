using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Business.ServiceInterfaces;
using Business.Business;
using DataAccess.Entities;
using DataAccess.Repositories.Linq;
using System.Data;

namespace TestEF
{
    class Program
    {
        static void Main(string[] args)
        {
            AddClause();
        }
        public static void TestDisposeDbContext() {
            IAccountBusiness accountService = new AccountService();

            Account a = new Account() { 
                Code="111",
                Description="111"
            };
            Account a1 = new Account()
            {
                Code = "222",
                Description = "222"
            };
            Account a2 = new Account()
            {
                Code = "333",
                Description = "333"
            };

            accountService.addAccountLevel1(a);
            accountService.addAccountLevel1(a1);
            accountService.addAccountLevel1(a2);
        }
        public static void TestAddMultiService() {
            IAccountBusiness accountService = new AccountService();
            IAccountClauseBusiness clauses = new AccountClauseService();

            AccountType type = clauses.GetAccountType("N");
            ProceduceType ptype = clauses.GetProceduceType(1);

            Account a = new Account()
            {
                Code = "111",
                Description = "111"
            };
            Account a1 = new Account()
            {
                Code = "222",
                Description = "222"
            };
            Account a2 = new Account()
            {
                Code = "333",
                Description = "333"
            };

            AccountClause clause = new AccountClause() { 
                Code="111",
                Description="111",
                ProceduceType=ptype
            };
            AccountClause clause1 = new AccountClause()
            {
                Code = "222",
                Description = "222",
                ProceduceType = ptype
            };
            AccountClause clause2 = new AccountClause()
            {
                Code = "333",
                Description = "333",
                ProceduceType = ptype
            };

            

            List<AccountClauseDetail> details = new List<AccountClauseDetail>();
            details.Add(new AccountClauseDetail() { 
                Account=a,
                AccountClause=clause,
                Description=a.Description
            });
            details.Add(new AccountClauseDetail()
            {
                Account = a1,
                AccountClause = clause1,
                Description = a1.Description
            });
            details.Add(new AccountClauseDetail()
            {
                Account = a2,
                AccountClause = clause2,
                Description = a2.Description
            });

            accountService.addAccountLevel1(a);
            accountService.addAccountLevel1(a1);
            accountService.addAccountLevel1(a2);

            //clauses.addAccountClause(clause);
            //clauses.addAccountClause(clause1);
            //clauses.addAccountClause(clause2);

            clauses.addBalanceAccounts(clause,details);
        }
        public static void TestAddClause() {
            using (var Context = new TaDalContext())
            {
                try
                {
                    var clauses = Context.Set<AccountClause>();
                    var types = Context.Set<ProceduceType>();
                    ProceduceType ptype = types.Find(1);

                    AccountClause clause = new AccountClause()
                    {
                        Code = "2222",
                        Description = "2222",
                        ProceduceType = ptype
                    };

                    clauses.Add(clause);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Context.Dispose();
                }
            }
        }
        public static void UpdateClause() {
            using (var Context = new TaDalContext())
            {
                try
                {
                   var clauses=Context.Set<AccountClause>();
                   var types=Context.Set<ProceduceType>();

                    AccountClause clause=clauses.Find(1);
                    ProceduceType ptype = types.Find(1);
                    clause.ProceduceType=ptype;
                    clause.Description = "aaaaaaaa";

                    clauses.Attach(clause);
                    Context.Entry(clause).State = EntityState.Modified;
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                   
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }
        public static void AddClause() {
            IAccountClauseBusiness clauses = new AccountClauseService();

            ProceduceType ptype = clauses.GetProceduceType(1);

            AccountClause clause = new AccountClause()
            {
                Code = "2222",
                Description = "2222",
                ProceduceType = ptype
            };
            clauses.addAccountClause(clause,ptype.Id);
        }
    }
}
