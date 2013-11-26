using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using log4net.Repository;
using Common.Exceptions;
using Common.Messages;

namespace Common.Logs
{
    public class WriteLog
    {
        private static LogBase _logger;
        private static void Instance(Type type) {
            _logger = new LogBase(type);
        }

        private static LogBase logger {
            get {
                return _logger;
            }
        }
        public static void ErrorDbCommon(Type type, Exception ex) {
            Error(type, ex);
            throw new UserException(ErrorsManager.DbError0000);
        }
        public static void ErrorCommon(Type type, Exception ex)
        {
            Error(type, ex);
            throw new UserException(ErrorsManager.Error0000);
        }
        public static void Error(Type type, Exception ex)
        {
            Instance(type);
            logger.Log.Error(ex.Message, ex);
        }
        public static void Warnning(Type type, Exception ex) {
            Instance(type);
            logger.Log.Warn(ex.Message, ex);
        }
        public static void Debug(Type type, Exception ex)
        {
            Instance(type);
            logger.Log.Debug(ex.Message, ex);
        }
        public static void Info(Type type, Exception ex)
        {
            Instance(type);
            logger.Log.Info(ex.Message, ex);
        }
        public static void Fatal(Type type, Exception ex)
        {
            Instance(type);
            logger.Log.Fatal(ex.Message, ex);
        }
    }
    public class LogBase
    {
        private Type _type;
        public ILog Log
        {
            get
            {
                return LogManager.GetLogger(_type);
            }
        }
        public LogBase(Type type)
        {
            DOMConfigurator.Configure();
            _type = type;
        }
    }
}
