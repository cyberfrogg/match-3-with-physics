using Game.Presenters.Player;
using Game.Presenters.Player.Impl;
using Game.Views.Player;
using ProtoYeet.Core.Factory;
using Zenject;

namespace Game.Factories.Player.Impl
{
    public class PlayerPresenterFactory : IPlayerPresenterFactory
    {
        private readonly DiContainer _container;

        public PlayerPresenterFactory(
            DiContainer container
            )
        {
            _container = container;
        }

        public IPlayerPresenter Create(IPlayerView playerView)
        {
            var presenter = new PlayerPresenter(playerView);
            FactoryUtils.Inject(_container, presenter);

            _container.BindInterfacesAndSelfTo<IPlayerPresenter>().FromInstance(presenter).NonLazy();

            return presenter;
        }
    }
}