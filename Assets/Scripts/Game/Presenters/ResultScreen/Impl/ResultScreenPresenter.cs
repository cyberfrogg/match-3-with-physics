using Game.Services.Score;
using Game.Views.ResultScreen;
using ProtoYeet.Core.Loading.Services.LevelLoading;
using ProtoYeet.Core.Services.PresentersPool;
using Zenject;

namespace Game.Presenters.ResultScreen.Impl
{
    public class ResultScreenPresenter : IResultScreenPresenter
    {
        [Inject] private readonly IScoreService _scoreService;
        [Inject] private readonly ILevelLoadingService _levelLoadingService;
        [Inject] private readonly IPresentersPool _presentersPool;
        
        public ResultScreenPresenter(
            IResultScreenView view
            )
        {
            View = view;
        }

        public IResultScreenView View { get; }
        
        public void OnInject()
        {
            View.Toggle(false);

            View.OnDestroyEvent += OnDestroy;

            View.ReplayPressedEvent += OnReplayPressed;
            View.MenuPressedEvent += OnMenuPressed;
        }

        private void OnDestroy()
        {
            View.OnDestroyEvent -= OnDestroy;

            View.ReplayPressedEvent -= OnReplayPressed;
            View.MenuPressedEvent -= OnMenuPressed;
            
            _presentersPool.Remove(this);
        }

        private void OnMenuPressed()
        {
            _levelLoadingService.Load("Menu");
        }

        private void OnReplayPressed()
        {
            _levelLoadingService.Load("SandBox");
        }

        public void Show()
        {
            View.Toggle(true);
            View.SetScore(_scoreService.Score);
        }
    }
}