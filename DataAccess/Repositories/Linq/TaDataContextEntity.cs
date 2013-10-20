using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;

namespace DataAccess.Repositories.Linq
{
    public class TaDataContextEntity<T> where T:class
    {
        private TaDalContext _DbContext;
        
        public DbSet<T> Entities {
            get { return Context.Set<T>(); }
        }
        public TaDalContext Context {
            get {
                if (_DbContext == null)
                    _DbContext = new TaDalContext(GlobalConstant.DBConnecstring);
                return _DbContext;
            }
            set {
                _DbContext = value;
            }
        }
        protected void ContextAdd(T entity) {
            Entities.Add(entity);
            Context.SaveChanges();
        }
        protected void ContextUpdate(T entity) {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        protected void ContextSave(T entity)
        {
            Entities.Add(entity);
            Context.SaveChanges();
        }
        protected void ContextDelete(int id)
        {
            var obj = ContextGet(id);
            Entities.Remove(obj);
            Context.SaveChanges();
        }
        protected T ContextGet(int id)
        {
            return Entities.Find(id);
        }
        public virtual IEnumerable<T> GetAll() {
            return Entities;
        }
        public virtual void Add(T entity) {
            ContextAdd(entity);
        }
        public virtual void Update(T entity) {
            ContextUpdate(entity);
        }
        public virtual void Delete(int id) {
            ContextDelete(id);
        }
        public virtual T Get(int id) {
            return ContextGet(id);
        }

        public virtual void AddList(List<T> list) {
            foreach (var e in list) {
                Entities.Add(e);
            }
            Context.SaveChanges();
        }
        public virtual void UpdateList(List<T> list) {
            foreach (var entity in list) {
                Context.Entry(entity).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }
        public virtual void DeleteList(List<T> list){
            foreach (var entity in list) {
                Entities.Remove(entity);
            }
            Context.SaveChanges();
        }
    }
}
