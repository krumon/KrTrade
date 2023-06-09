﻿using KrTrade.Nt.DI.Options;

namespace KrTrade.Nt.DI.Logging.File
{
    internal sealed class DefaultFileFormatterConfigureOptions : ConfigureOptions<FileFormatterOptions>
    {
        public DefaultFileFormatterConfigureOptions() : base(options => 
        {
            options.Singleline = true;
            options.LogLevel = true;
            options.TimestampOptions = new TimestampOptions()
            {
                LogDate = true,
                LogTime = true,
                LogMilliseconds = false,
                UseUtcTimestamp = false,
                TimestampFormat="yyyy/MM/dd HH:mm:ss"
            };

        }) { }
    }
}
