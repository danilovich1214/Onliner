using log4net;
using log4net.Config;

namespace OnlinerLibrary
{
    public class Logger
    {
        private static readonly ILog Log;
        private static Logger _instance;

        static Logger()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Fail(string message)
        {
            Log.Fatal(message);
        }

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Debug(string format)
        {
            Log.Debug(format);
        }

        public void LogStep(int step, string message)
        {
            Info(
                $"---[ Step {step} ]: {message}");
        }
    }
}
