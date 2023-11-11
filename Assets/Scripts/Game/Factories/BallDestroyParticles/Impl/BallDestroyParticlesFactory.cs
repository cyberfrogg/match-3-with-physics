using Game.Presenters.BallDestroyParticles;
using Game.Presenters.BallDestroyParticles.Impl;
using Game.Views.BallDestroyParticles;
using ProtoYeet.Core.Factory;
using ProtoYeet.Core.Services.PrefabSpawn;
using ProtoYeet.Core.Services.PresentersPool;
using Zenject;

namespace Game.Factories.BallDestroyParticles.Impl
{
    public class BallDestroyParticlesFactory : IBallDestroyParticlesFactory
    {
        private readonly DiContainer _container;
        private readonly IPresentersPool _presentersPool;
        private readonly IPrefabSpawnService _prefabSpawnService;

        public BallDestroyParticlesFactory(
            DiContainer diContainer,
            IPresentersPool presentersPool,
            IPrefabSpawnService prefabSpawnService
            )
        {
            _container = diContainer;
            _presentersPool = presentersPool;
            _prefabSpawnService = prefabSpawnService;
        }

        public IBallDestroyParticlesPresenter Create()
        {
            var view = _prefabSpawnService.Spawn<IBallDestroyParticlesView>("BallDestroyParticles");
            var presenter = new BallDestroyParticlesPresenter(view);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IBallDestroyParticlesPresenter>().FromInstance(presenter).NonLazy();
            _presentersPool.Add(presenter);

            return presenter;
        }
    }
}