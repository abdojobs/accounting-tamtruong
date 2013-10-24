using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace DataAccess.Repositories.Harsh
{
    class TaAccountEntity :TaDataEntity<Account>,ITaAccountRepository
    {


        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Account entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Account Get(int id)
        {
            throw new NotImplementedException();
        }

        public void AddList(List<Account> list)
        {
            throw new NotImplementedException();
        }

        public void UpdateList(List<Account> list)
        {
            throw new NotImplementedException();
        }

        public void DeleteList(List<Account> list)
        {
            throw new NotImplementedException();
        }


        public void AddSubmit(Account entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubmit(Account entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubmit(int id)
        {
            throw new NotImplementedException();
        }

        public void AddListSubmit(List<Account> list)
        {
            throw new NotImplementedException();
        }

        public void UpdateListSubmit(List<Account> list)
        {
            throw new NotImplementedException();
        }

        public void DeleteListSubmit(List<Account> list)
        {
            throw new NotImplementedException();
        }
    }
}
