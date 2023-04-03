using Serilog;
using TelegramSink;

namespace Car_Configuration.Extensions;

public static class LoggerExtensions
{
    public static void SerilogConfig(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.TeleSink("6125388892:AAGCbqi0A2gFYaJPtxMfIZUCcCdJlHZ-kSQ", "2039076116", minimumLevel: Serilog.Events.LogEventLevel.Error)
            .CreateLogger();

        builder.Logging.AddSerilog(logger);
    }
}