using UnityEngine;

namespace ProtoYeet.Core.Log.Services.Impl
{
    public class UnityLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void LogSceneSwitching(string loadScene)
        {
            Debug.Log($"[Loading Scene]: {loadScene}");
        }

        public void LogBootstrap(string message)
        {
            Debug.Log($"[Bootstrap]: {message}");
        }

        public void Warn(string message)
        {
            Debug.LogWarning(message);
        }

        public void Error(string message)
        {
            Debug.LogError(message);
        }
    }
}