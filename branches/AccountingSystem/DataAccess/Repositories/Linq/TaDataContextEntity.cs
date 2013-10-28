using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaDataContextEntity<T> where T:class
    {
        private TaDalContext _DbContext;

        //public DbSet<T> Entities
        //{
        //    get { return Context.Set<T>(); }
        //}
        //public TaDalContext Context
        //{
        //    get
        //    {
        //        if (_DbContext == null)
        //            _DbContext = new TaDalContext(GlobalConstant.DBConnecstring);

        //        return _DbContext;
        //    }
        //    set
        //    {
        //        _DbContext = value;
        //    }
        //}
        protected TaDalContext CreateContext() {
            return new TaDalContext(GlobalConstant.DBConnecstring);
        }
        protected void ContextAdd(T entity) {
            using (var Context = CreateContext())
            {
                try
                {
                    Context.Set<T>().Add(entity);
                    Context.SaveChanges();
                    
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }
        protected void ContextUpdate(T entity) {

            using (var Context = CreateContext())
            {
                try
                {
                    //Context.Entry(entity).State = EntityState.Modified;
                    //Context.Entry(entity).CurrentValues.SetValues(entity);
                    //Context.SaveChanges();


                    var entry = Context.Entry<T>(entity);
                    var pkey = Context.Set<T>().Create().GetType().GetProperty("Id").GetValue(entity, null);

                    if (entry.State == EntityState.Detached)
                    {
                        var set = Context.Set<T>();
                        T attachedEntity = set.Find(pkey);  // You need to have access to key
                        if (attachedEntity != null)
                        {
                            var attachedEntry = Context.Entry(attachedEntity);
                            attachedEntry.CurrentValues.SetValues(entity);
                        }
                        else
                        {
                            entry.State = EntityState.Modified; // This should attach entity
                        }
                        Context.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
           
        }
        protected void ContextSave(T entity)
        {
            using (var Context = CreateContext())
            {
                try
                {
                   
                    Context.Set<T>().Add(entity);
                    Context.SaveChanges();

                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        protected void ContextDelete(int id)
        {
            using (var Context = CreateContext())
            {
                try
                {
                    var obj = ContextGet(id);
                    Context.Set<T>().Remove(obj);
                    Context.SaveChanges();

                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        protected T ContextGet(int id)
        {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    return Context.Set<T>().Find(id);
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual IEnumerable<T> GetAll() {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    return Context.Set<T>();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void Add(T entity) {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    Context.Set<T>().Add(entity);
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void Update(T entity) {
            using (var Context = CreateContext())
            {
                try
                {
                    Context.Set<T>().Attach(entity);
                    Context.Entry(entity).State = EntityState.Modified;
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void Delete(int id) {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    var obj = ContextGet(id);
                    Context.Set<T>().Remove(obj);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual T Get(int id) {
            return ContextGet(id);
        }

        public virtual void AddList(List<T> list) {
            foreach (var e in list) {
                Add(e);
            }
        }
        public virtual void UpdateList(List<T> list) {
            foreach (var entity in list) {
                Update(entity);
            }
        }
        public virtual void DeleteList(List<T> list){
            using (var Context = CreateContext())
            {
                try
                {
                    foreach (var entity in list)
                    {
                        Context.Set<T>().Remove(entity);
                    }
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }

        public virtual void AddSubmit(T entity) {
            ContextAdd(entity);
        }
        public virtual void AddListSubmit(List<T> list) {
            using (var Context = CreateContext())
            {
                try
                {
                    foreach (var e in list)
                    {
                        Context.Set<T>().Add(e);
                    }
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void UpdateSubmit(T entity)
        {
            using (var Context = CreateContext())
            {
                try
                {
                    ContextUpdate(entity);

                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void DeleteSubmit(int id)
        {
            ContextDelete(id);
        }
        public virtual void UpdateListSubmit(List<T> list)
        {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    foreach (var entity in list)
                    {
                        Context.Entry(entity).State = EntityState.Modified;
                    }
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void DeleteListSubmit(List<T> list)
        {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    foreach (var entity in list)
                    {
                        Context.Set<T>().Remove(entity);
                    }
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
        public virtual void DeleteSubmit(T entity) {
            using (var Context = CreateContext())
            {
                try
                {
                    
                    Context.Set<T>().Remove(entity);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Context.Dispose();
                }
            }
            
        }
    }
}
