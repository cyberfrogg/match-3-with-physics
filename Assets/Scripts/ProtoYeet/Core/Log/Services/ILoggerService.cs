namespace ProtoYeet.Core.Log.Services
{
    public interface ILoggerService
    {
        void Log(string message);
        void LogSceneSwitching(string loadScene);
        void LogBootstrap(string message);
        void Log(object logClass, string message);
        void Warn(string message);
        void Error(string message);
    }
}