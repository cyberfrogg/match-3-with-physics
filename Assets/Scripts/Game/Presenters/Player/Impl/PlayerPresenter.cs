using Game.Views.Player;

namespace Game.Presenters.Player.Impl
{
    public class PlayerPresenter : IPlayerPresenter
    {
        public IPlayerView View { get; private set; }
        
        public PlayerPresenter(IPlayerView playerView)
        {
            View = playerView;
        }
    }
}