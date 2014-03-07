namespace CarRentals.Core.Common.Logging
{
    public interface ILogger
    {
        void Log(string category, LogLevel level, string message ,string eventId  = null);
    }

    public enum LogLevel
    {
        FATAL = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        VERBOSE = 4        
    }
}