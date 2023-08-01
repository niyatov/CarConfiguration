using Serilog;
using TelegramSink;

namespace Car_Configuration.Extensions;

public static class LoggerExtensions
{
    public static void SerilogConfig(this WebApplicationBuilder builder, ConfigurationManager configuration)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.TeleSink(configuration.GetSection("MySettings").GetSection("BotToken").Value, configuration.GetSection("MySettings").GetSection("ChatId").Value, minimumLevel: Serilog.Events.LogEventLevel.Error)
            .CreateLogger();

        builder.Logging.AddSerilog(logger);
    }
}
