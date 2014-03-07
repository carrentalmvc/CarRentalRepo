using log4net;

namespace CarRentals.Core.Common.Logging
{
    /// <summary>
    /// Refer to this article https://www.simple-talk.com/dotnet/.net-framework/designing-c-software-with-interfaces/
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Log(string category, LogLevel level, string message ,string eventId = null)
        {
            var logger = LogManager.GetLogger(category);
            switch (level)
            {
                case LogLevel.FATAL:
                    if (logger.IsFatalEnabled)
                    {
                        logger.Fatal(message);
                    }
                    break;

                case LogLevel.ERROR:
                    if (logger.IsErrorEnabled)
                    {
                        if(!string.IsNullOrWhiteSpace(eventId))
                        {
                            log4net.ThreadContext.Properties["EventID"] = eventId;
                        }
                        logger.Error(message);
                    }
                    break;

                case LogLevel.WARN:
                    if (logger.IsWarnEnabled)
                    {
                        logger.Warn(message);
                    }
                    break;

                case LogLevel.INFO:
                    if (logger.IsInfoEnabled)
                    {
                        logger.Info(message);
                    }
                    break;

                case LogLevel.VERBOSE:
                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug(message);
                    }
                    break;
            }
        }
    }
}