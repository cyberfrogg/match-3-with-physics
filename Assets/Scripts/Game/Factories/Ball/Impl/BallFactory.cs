using Game.Presenters.Ball;
using Game.Presenters.Ball.Impl;
using Game.Views.Ball;
using ProtoYeet.Core.Factory;
using ProtoYeet.Core.Services.PrefabSpawn;
using ProtoYeet.Core.Services.PresentersPool;
using Zenject;

namespace Game.Factories.Ball.Impl
{
    public class BallFactory : IBallFactory
    {
        private readonly DiContainer _container;
        private readonly IPrefabSpawnService _prefabSpawnService;
        private readonly IPresentersPool _presentersPool;

        public BallFactory(
            DiContainer container,
            IPrefabSpawnService prefabSpawnService,
            IPresentersPool presentersPool
        )
        {
            _container = container;
            _prefabSpawnService = prefabSpawnService;
            _presentersPool = presentersPool;
        }
        
        public IBallPresenter Create()
        {
            var viewInstance = _prefabSpawnService.Spawn<IBallView>("Ball");
            var presenter = new BallPresenter(viewInstance);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IBallPresenter>().FromInstance(presenter).NonLazy();
            _presentersPool.Add(presenter);

            return presenter;
        }
    }
}