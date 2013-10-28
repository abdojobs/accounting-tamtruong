using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ITaRepositoryBase<T> where T:class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T Get(int id);
        void AddList(List<T> list);
        void UpdateList(List<T> list);
        void DeleteList(List<T> list);

        void AddSubmit(T entity);
        void UpdateSubmit(T entity);
        void DeleteSubmit(int id);
        void AddListSubmit(List<T> list);
        void UpdateListSubmit(List<T> list);
        void DeleteListSubmit(List<T> list);
        void DeleteSubmit(T entity);
    }
}
