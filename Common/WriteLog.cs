using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace Common
{
    public class WriteLog
    {
        private ILog _logger;
        private ILog logger(Type type){
            if(_logger==null)
                _logger=LogManager.GetLogger(type);
            return _logger;
        }
        public static void Error(Type type, Exception ex) { 
               
        }
    }
    public class LogBase {
        private ILoggerRepository _logger;
        private ILog logger(Type type)
        {
            if (_logger == null)
                _logger = LogManager.GetLogger(type);
            return _logger;
        }
        public LogBase() {
            DOMConfigurator.Configure();
            _logger = LogManager.GetRepository();
        }
    }
}
