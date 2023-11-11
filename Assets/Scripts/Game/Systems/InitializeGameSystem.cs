using Game.Factories.Column;
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
        private readonly IColumnFactory _columnFactory;

        public InitializeGameSystem(
            IGameFieldProvider gameFieldProvider,
            ILoggerService loggerService,
            DiContainer container,
            IColumnFactory columnFactory
            )
        {
            _gameFieldProvider = gameFieldProvider;
            _loggerService = loggerService;
            _container = container;
            _columnFactory = columnFactory;
        }

        public void Initialize()
        {
            _loggerService.Log(this, "Initialize Game");
            
            CreateColumns();
            CreateCamera();
        }

        private void CreateColumns()
        {
            foreach (var columnView in _gameFieldProvider.GameFieldView.ColumnViews)
            {
                _columnFactory.Create(columnView);
            }
        }

        private void CreateCamera()
        {
            
        }
    }
}