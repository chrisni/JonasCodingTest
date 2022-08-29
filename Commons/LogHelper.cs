using System;

namespace Commons.LogHelper
{
    public class LogHelper
    {
        private static Ilogger _loggerInstance = new TextLogger();

        public static Ilogger LoggerInstance
        {
            get { return _loggerInstance; }
        }

        public static void LogInfo(string info)
        {
            var logInfo = String.Format("{0}:{1}", DateTime.Now.ToString(), info);
            LoggerInstance.Log(logInfo);
        }

        public static void LogWarning(string warningMessage)
        {
            var logWarning = String.Format("{0}:{1}", DateTime.Now.ToString(), warningMessage);
            LoggerInstance.Log(logWarning);
        }

        public static void LogError(string errorMessage)
        {
            var logError = String.Format("{0}:{1}", DateTime.Now.ToString(), errorMessage);
            LoggerInstance.Log(logError);
        }

        public static void LogError(Exception e)
        {
            var logError = String.Format("{0}:{1}", DateTime.Now.ToString(), e.Message);
            var logStackTrace = String.Format("{0}:{1}", DateTime.Now.ToString(), e.StackTrace);

            LoggerInstance.Log(logError);
            LoggerInstance.Log(logStackTrace);
        }
    }

}
