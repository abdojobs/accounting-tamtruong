using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Reflection;
using DataAccess.Attributes;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    /// <summary> 
    ///  Try to analyze the ModelEntity by reflecting them one by one and then 
    ///  fetch the properties with "unique" attribute and then do calling Sql statement to create database. 
    /// </summary> 
    /// <typeparam name="T"></typeparam> 
    public class TaDbGenerator<T> : IDatabaseInitializer<T> where T : DbContext
    {
        public void InitializeDatabase(T context)
        {
            //context.Database.Delete();
            //context.Database.Create();
            ////Fetch all the father class's public properties 
            //var fatherPropertyNames = typeof(DbContext).GetProperties().Select(pi => pi.Name).ToList();
            ////Loop each dbset's T 

            ////ignore unique type

            //foreach (PropertyInfo item in typeof(T).GetProperties().Where(p => fatherPropertyNames.IndexOf(p.Name) < 0 && !IsIgnoreUnique(p.PropertyType.GetGenericArguments()[0])).Select(p => p))
            //{
            //    //fetch the type of "T" 
            //    Type entityModelType = item.PropertyType.GetGenericArguments()[0];
            //    var allfieldNames = from prop in entityModelType.GetProperties()
            //                        where prop.GetCustomAttributes(typeof(UniqueKeyAttribute), true).Count() > 0
            //                        select prop.Name;
            //    foreach (string s in allfieldNames)
            //    {
            //        context.Database.ExecuteSqlCommand("alter table " + entityModelType.Name + " add unique(" + s + ")");
            //    }
            //}
            
        }

        private List<Type> ListIgnoreUnique() {
            List<Type> list = new List<Type>();
            list.Add(typeof(DeliveryPerson));
            list.Add(typeof(Receiver));
            list.Add(typeof(Supplier));
            list.Add(typeof(TradingPartner));
            return list;
        }

        private bool IsIgnoreUnique(Type type) {
            var ignorelist = ListIgnoreUnique();
            return ignorelist.Where(t => t.Name == type.Name).FirstOrDefault() == null ? false : true;
        }
        
    } 
 
}
