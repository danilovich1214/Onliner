﻿using log4net;
using log4net.Config;

namespace OnlinerLibrary
{
    public class Logger
    {
        private readonly ILog _log;
        private static Logger _instance;

        private Logger()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Fail(string message)
        {
            _log.Fatal(message);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Debug(string format)
        {
            _log.Debug(format);
        }

        public void LogStep(int step, string message)
        {
            Info(
                $"<font style='color: #ffffff; background-color: grey'>------------------------------------------[ Step {step} ]: {message}</font>");
        }
    }
}
