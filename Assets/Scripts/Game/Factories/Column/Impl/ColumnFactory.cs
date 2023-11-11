using Game.Presenters.Column;
using Game.Presenters.Column.Impl;
using Game.Views.Column;
using ProtoYeet.Core.Factory;
using ProtoYeet.Core.Services.PresentersPool;
using Zenject;

namespace Game.Factories.Column.Impl
{
    public class ColumnFactory : IColumnFactory
    {
        private readonly DiContainer _container;
        private readonly IPresentersPool _presentersPool;

        public ColumnFactory(
            DiContainer container,
            IPresentersPool presentersPool
        )
        {
            _container = container;
            _presentersPool = presentersPool;
        }
        
        public IColumnPresenter Create(IColumnView columnView)
        {
            var presenter = new ColumnPresenter(columnView);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IColumnPresenter>().FromInstance(presenter).NonLazy();
            _presentersPool.Add(presenter);

            return presenter;
        }
    }
}