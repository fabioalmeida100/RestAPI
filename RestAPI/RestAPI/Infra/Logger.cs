using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Infra
{
    public class Logger : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new Internallogger();
        }

        public void Dispose()
        {

        }

        private class Internallogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
               return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                System.IO.File.AppendAllText(@"LogEntityFramework.txt", formatter(state, exception));               
            }
        }
    }
}
