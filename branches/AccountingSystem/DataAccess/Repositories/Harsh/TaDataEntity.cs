using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Harsh
{
    public class TaDataEntity<T> where T:class
    {
        private IList<T> _EntitiesList;
        public IList<T> EntitiesList {
            get {
                return _EntitiesList;
            }
            set {
                _EntitiesList = value;
            }
        }
        
    }
}
