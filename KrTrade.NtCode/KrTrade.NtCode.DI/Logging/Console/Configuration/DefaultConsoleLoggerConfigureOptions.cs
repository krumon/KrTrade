﻿using KrTrade.NtCode.Options;

namespace KrTrade.NtCode.Logging.Console
{
    internal sealed class DefaultConsoleLoggerConfigureOptions : ConfigureOptions<ConsoleLoggerOptions>
    {
        public DefaultConsoleLoggerConfigureOptions() : base(options => { })
        {
        }
    }
}
