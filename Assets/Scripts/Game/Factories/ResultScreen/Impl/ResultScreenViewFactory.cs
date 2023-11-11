using Game.Presenters.ResultScreen;
using Game.Presenters.ResultScreen.Impl;
using Game.Views.ResultScreen;
using ProtoYeet.Core.Factory;
using ProtoYeet.Core.Services.PresentersPool;
using Zenject;

namespace Game.Factories.ResultScreen.Impl
{
    public class ResultScreenViewFactory : IResultScreenFactory
    {
        private readonly DiContainer _container;
        private readonly IPresentersPool _presentersPool;

        public ResultScreenViewFactory(
            DiContainer container,
            IPresentersPool presentersPool
        )
        {
            _container = container;
            _presentersPool = presentersPool;
        }

        public IResultScreenPresenter Create(IResultScreenView view)
        {
            var presenter = new ResultScreenPresenter(view);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IResultScreenPresenter>().FromInstance(presenter).NonLazy();
            _presentersPool.Add(presenter);

            return presenter;
        }
    }
}