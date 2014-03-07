using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Core.Common.Logging
{
    /// <summary>
    /// This should be called from all the classes that deals with some kind of LOgging
    /// Take a look at this https://github.com/dotnetcurry/csharp-caller-info/blob/master/CallerInfoSample/Logger.cs
    /// </summary>
   public  class LoggerFactory
    {
       private static ILogger logger;
       //private static object lockObject = new object();
       public static ILogger GetLogger()
       {

           return new Log4NetLogger();

           //lock (lockObject)
           //{
           //    if (logger == null)
           //    {
           //        var assyName = ConfigurationManager.AppSettings["log4net"];
           //        var className = ConfigurationManager.AppSettings["Logger.ClassName"];
           //        if (string.IsNullOrWhiteSpace(assyName) || string.IsNullOrWhiteSpace(className))
           //        {
           //            throw new ApplicationException("Missing config data for Logger");
           //        }
           //        else
           //        {
           //            var assembly = Assembly.LoadFrom(assyName);
           //            if (assembly != null)
           //            {
           //                logger = assembly.CreateInstance(className) as ILogger;
           //            }

           //            if (logger == null)
           //            {
           //                throw new ApplicationException(string.Format("Unable to instatntiate ILogger implementation from {0}/{1}", assyName, className));
           //            }
           //        }
                   
           //    }
           //}

           return logger;
          
       }
    }
}
