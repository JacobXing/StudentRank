using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Events;

namespace RankAPI
{
    public class SerilogOptions
    {
        public LogEventLevel RollingFileLogEventLevel { get; set; }
        public LogEventLevel ConsoleLogEventLevel { get; set; }
    }
}

