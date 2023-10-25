using Game.Presenters.Player;
using Game.Presenters.Player.Impl;
using Game.Views.Player;
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
            _container.Inject(presenter);

            _container.Bind<IPlayerPresenter>().FromInstance(presenter);

            return presenter;
        }
    }
}