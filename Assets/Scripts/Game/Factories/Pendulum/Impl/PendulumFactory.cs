using Game.Presenters.Pendulum;
using Game.Presenters.Pendulum.Impl;
using Game.Views.Pendulum;
using ProtoYeet.Core.Factory;
using ProtoYeet.Core.Services.PresentersPool;
using Zenject;

namespace Game.Factories.Pendulum.Impl
{
    public class PendulumFactory : IPendulumFactory
    {
        private readonly DiContainer _container;
        private readonly IPresentersPool _presentersPool;

        public PendulumFactory(
            DiContainer container,
            IPresentersPool presentersPool
        )
        {
            _container = container;
            _presentersPool = presentersPool;
        }
        
        public IPendulumPresenter Create(IPendulumView pendulumView)
        {
            var presenter = new PendulumPresenter(pendulumView);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IPendulumPresenter>().FromInstance(presenter).NonLazy();
            _presentersPool.Add(presenter);

            return presenter;
        }
    }
}