using Game.Factories.Ball;
using Game.Factories.Column;
using Game.Factories.Pendulum;
using Game.Factories.ResultScreen;
using Game.Providers.GameFieldProvider;
using Game.Services.PendulumAttach;
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
        private readonly IColumnFactory _columnFactory;
        private readonly IBallFactory _ballFactory;
        private readonly IPendulumFactory _pendulumFactory;
        private readonly IPendulumAttachService _pendulumAttachService;
        private readonly IResultScreenFactory _resultScreenFactory;

        public InitializeGameSystem(
            IGameFieldProvider gameFieldProvider,
            ILoggerService loggerService,
            DiContainer container,
            IColumnFactory columnFactory,
            IBallFactory ballFactory,
            IPendulumFactory pendulumFactory,
            IPendulumAttachService pendulumAttachService,
            IResultScreenFactory resultScreenFactory
            )
        {
            _gameFieldProvider = gameFieldProvider;
            _loggerService = loggerService;
            _container = container;
            _columnFactory = columnFactory;
            _ballFactory = ballFactory;
            _pendulumFactory = pendulumFactory;
            _pendulumAttachService = pendulumAttachService;
            _resultScreenFactory = resultScreenFactory;
        }

        public void Initialize()
        {
            _loggerService.Log(this, "Initialize Game");
            
            CreateColumns();
            CreatePendulum();
            CreateBall();
            CreateResultScreen();
        }

        private void CreateColumns()
        {
            foreach (var columnView in _gameFieldProvider.GameFieldView.ColumnViews)
            {
                _columnFactory.Create(columnView);
            }
        }

        private void CreatePendulum()
        {
            _pendulumFactory.Create(_gameFieldProvider.GameFieldView.PendulumView);
        }

        private void CreateBall()
        {
            var ball = _ballFactory.Create();
            _pendulumAttachService.Attach(ball);
        }
        
        private void CreateResultScreen()
        {
            _resultScreenFactory.Create(_gameFieldProvider.GameFieldView.ResultScreenView);
        }
    }
}