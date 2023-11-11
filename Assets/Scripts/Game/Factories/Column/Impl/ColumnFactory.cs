using Game.Presenters.Column;
using Game.Presenters.Column.Impl;
using Game.Views.Column;
using ProtoYeet.Core.Factory;
using Zenject;

namespace Game.Factories.Column.Impl
{
    public class ColumnFactory : IColumnFactory
    {
        private readonly DiContainer _container;

        public ColumnFactory(
            DiContainer container
        )
        {
            _container = container;
        }
        
        public IColumnPresenter Create(IColumnView columnView)
        {
            var presenter = new ColumnPresenter(columnView);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IColumnPresenter>().FromInstance(presenter).NonLazy();

            return presenter;
        }
    }
}