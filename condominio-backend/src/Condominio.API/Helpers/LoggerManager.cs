using Condominio.Application.Repository;
using NLog;

namespace Condominio.API.Helpers
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public void LogInfo(string mensagem)
        {
            Logger.Info(mensagem);
        }

        public void LogWarn(string mensagem)
        {
            Logger.Warn(mensagem);
        }

        public void LogDebug(string mensagem)
        {
            Logger.Debug(mensagem);
        }

        public void LogError(string mensagem)
        {
            Logger.Error(mensagem);
        }
    }
}