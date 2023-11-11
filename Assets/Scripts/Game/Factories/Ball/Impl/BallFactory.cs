using System;
using Game.Data;
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
        private readonly Random _random;

        public BallFactory(
            DiContainer container,
            IPrefabSpawnService prefabSpawnService,
            IPresentersPool presentersPool
        )
        {
            _container = container;
            _prefabSpawnService = prefabSpawnService;
            _presentersPool = presentersPool;
            _random = new Random();
        }
        
        public IBallPresenter Create()
        {
            var viewInstance = _prefabSpawnService.Spawn<IBallView>("Ball");
            var ballType = GetRandomType();
            var presenter = new BallPresenter(viewInstance, ballType);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IBallPresenter>().FromInstance(presenter).NonLazy();
            _presentersPool.Add(presenter);

            return presenter;
        }

        private EBallType GetRandomType()
        {
            var v = Enum.GetValues (typeof (EBallType));
            return (EBallType) v.GetValue (_random.Next(v.Length));
        }
    }
}