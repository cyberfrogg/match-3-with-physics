using Game.Views.Player;
using ProtoYeet.Core.Bootstrap.Services.GameLoop;
using ProtoYeet.Core.Log.Services;
using ProtoYeet.Core.Systems;
using Zenject;

namespace Game.Presenters.Player.Impl
{
    public class PlayerPresenter : IPlayerPresenter, IUpdateSystem
    {
        [Inject] private readonly ILoggerService _loggerService;
        [Inject] private readonly IGameLoopManager _gameLoopManager;
        
        public IPlayerView View { get; }
        
        public PlayerPresenter(
            IPlayerView playerView
            )
        {
            View = playerView;
        }

        public void Update()
        {
            
        }

        public void OnInject()
        {
            _gameLoopManager.AddUpdateListener(this);
            View.OnDestroyEvent += OnDestroyEvent;
        }

        private void OnDestroyEvent()
        {
            View.OnDestroyEvent -= OnDestroyEvent;
            _gameLoopManager.RemoveUpdateListener(this);
        }
    }
}