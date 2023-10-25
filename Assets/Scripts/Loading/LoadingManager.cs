using ProtoYeet.Core.Loading.Services.LevelLoading;
using ProtoYeet.Core.Loading.Services.SceneLoading;
using ProtoYeet.Core.Log.Services;
using UnityEngine;
using Zenject;

namespace Loading
{
    public class LoadingManager : MonoBehaviour
    {
        [Inject] private ILevelLoadingService _levelLoadingService;
        [Inject] private ISceneLoadingService _sceneLoadingService;
        [Inject] private ILoggerService _loggerService;
        
        private void Start()
        {
            _loggerService.LogSceneSwitching(_levelLoadingService.NextLevelToLoad);
            _sceneLoadingService.LoadScene(_levelLoadingService.NextLevelToLoad);
        }
    }
}