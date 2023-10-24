using ProtoYeet.Core.Loading.Services.LevelLoading;
using ProtoYeet.Core.Loading.Services.SceneLoading;
using UnityEngine;
using Zenject;

namespace Loading
{
    public class LoadingManager : MonoBehaviour
    {
        [Inject] private ILevelLoadingService _levelLoadingService;
        [Inject] private ISceneLoadingService _sceneLoadingService;
        
        private void Start()
        {
            _sceneLoadingService.LoadScene(_levelLoadingService.NextLevelToLoad);
        }
    }
}