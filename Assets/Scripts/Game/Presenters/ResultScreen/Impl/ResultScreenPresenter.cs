using Game.Services.Score;
using Game.Views.ResultScreen;
using Zenject;

namespace Game.Presenters.ResultScreen.Impl
{
    public class ResultScreenPresenter : IResultScreenPresenter
    {
        [Inject] private readonly IScoreService _scoreService;
        
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
        }

        public void Show()
        {
            View.Toggle(true);
            View.SetScore(_scoreService.Score);
        }
    }
}