using ProtoYeet.Core.Loading.Services.SceneLoading;
using UnityEngine;
using Zenject;

namespace ProtoYeet.Core.Splash
{
    public class SplashManager : MonoBehaviour
    {
        [Inject] private ISceneLoadingService _sceneLoadingService;
        
        private void Start()
        {
            _sceneLoadingService.LoadScene("Menu");
        }
    }
}