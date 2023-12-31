using ProtoYeet.Core.Loading.Services.LevelLoading;
using ProtoYeet.Core.Log.Services;
using ProtoYeet.Core.Systems;
using ProtoYeet.Ui.Abstracts;
using UnityEngine;
using Zenject;

namespace Menu.Ui.MenuScreen
{
    public class MenuScreenView : UiView, IUiInitialize
    {
        [SerializeField] private AButton StartCampaignButton;
        [SerializeField] private AButton StartSandBoxButton;
        
        [Inject] private ILoggerService _logger;
        [Inject] private ILevelLoadingService _levelLoadingService;

        public void Initialize()
        {
            StartCampaignButton.Click += OnStartCampaign;
            StartSandBoxButton.Click += OnStartSandBox;
        }

        private void OnStartCampaign()
        {
            _logger.Log("Starting campaign...");
        }

        private void OnStartSandBox()
        {
            _levelLoadingService.Load("SandBox");
        }
    }
}