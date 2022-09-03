using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NLog;
using NLog.Web;

namespace MirrorLink.Api.Middleware
{
    public class LoggingMiddleware
    {
        private const string NLogConfigName = "NLog.config";
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = NLogBuilder.ConfigureNLog(NLogConfigName)
                .GetCurrentClassLogger();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
#if DEBUG
                _logger.Log(LogLevel.Trace, GetIncomingIp(context));
#endif
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
            finally
            {
                _logger.Info(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }

        private string GetIncomingIp(HttpContext context)
        {
            return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}