using Game.Presenters.Player;
using Game.Views.Player;

namespace Game.Factories.Player
{
    public interface IPlayerPresenterFactory
    {
        IPlayerPresenter Create(IPlayerView playerView);
    }
}