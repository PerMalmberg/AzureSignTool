using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AzureSignTool
{
    public class Scope : IDisposable
    {
        public void Dispose()
        {            
        }
    }

    public class FlushingLogger : Microsoft.Extensions.Logging.ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new Scope();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var s = string.Format("{0}: {1}", logLevel.ToString(), formatter(state, exception));
            Console.WriteLine(s);
            Console.Out.Flush();
        }
    }
}
