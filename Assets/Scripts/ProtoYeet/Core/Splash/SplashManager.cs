using ProtoYeet.Core.Loading.Services.LevelLoading;
using UnityEngine;
using Zenject;

namespace ProtoYeet.Core.Splash
{
    public class SplashManager : MonoBehaviour
    {
        [Inject] private ILevelLoadingService _levelLoadingService;
        
        private void Start()
        {
            _levelLoadingService.Load("Menu");
        }
    }
}