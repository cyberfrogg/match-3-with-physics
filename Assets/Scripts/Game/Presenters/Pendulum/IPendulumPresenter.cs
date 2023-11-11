using Game.Presenters.Ball;
using Game.Views.Pendulum;
using ProtoYeet.Abstracts;

namespace Game.Presenters.Pendulum
{
    public interface IPendulumPresenter : IPresenter<IPendulumView>, IInjectable
    {
        void AttachBall(IBallPresenter ballPresenter);
        IBallPresenter DetachBall();
        IBallPresenter CurrentAttachedBall { get; }
    }
}