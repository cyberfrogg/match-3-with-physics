using Game.Presenters.Ball;

namespace Game.Services.PendulumAttach
{
    public interface IPendulumAttachService
    {
        IBallPresenter CurrentAttachedBall { get; }
        void Attach(IBallPresenter ball);
        IBallPresenter Detach();
    }
}