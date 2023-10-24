using Game.Factories.Player;
using Game.Providers.GameFieldProvider;
using ProtoYeet.Core.Log.Services;
using ProtoYeet.Core.Systems;
using Zenject;

namespace Game.Systems
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly ILoggerService _loggerService;
        private readonly DiContainer _container;
        private readonly IPlayerPresenterFactory _playerPresenterFactory;

        public InitializeGameSystem(
            IGameFieldProvider gameFieldProvider,
            ILoggerService loggerService,
            DiContainer container,
            IPlayerPresenterFactory playerPresenterFactory
            )
        {
            _gameFieldProvider = gameFieldProvider;
            _loggerService = loggerService;
            _container = container;
            _playerPresenterFactory = playerPresenterFactory;
        }

        public void Initialize()
        {
            _loggerService.Log(this, "Initialize Game");
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            var playerView = _gameFieldProvider.GameFieldView.PlayerView;
            _playerPresenterFactory.Create(playerView);
        }
    }
}