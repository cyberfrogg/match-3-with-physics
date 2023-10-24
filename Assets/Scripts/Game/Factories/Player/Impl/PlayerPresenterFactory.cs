using Game.Presenters.Player;
using Game.Views.Player;
using Zenject;

namespace Game.Factories.Player.Impl
{
    public class PlayerPresenterFactory : PlaceholderFactory<IPlayerView, IPlayerPresenter>, IPlayerPresenterFactory
    {

    }
}