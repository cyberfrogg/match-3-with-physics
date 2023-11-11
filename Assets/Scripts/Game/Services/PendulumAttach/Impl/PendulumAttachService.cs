using Game.Presenters.Ball;
using Game.Presenters.Pendulum;
using ProtoYeet.Core.Services.PresentersPool;

namespace Game.Services.PendulumAttach.Impl
{
    public class PendulumAttachService : IPendulumAttachService
    {
        private readonly IPresentersPool _presentersPool;

        public PendulumAttachService(
            IPresentersPool presentersPool
            )
        {
            _presentersPool = presentersPool;
        }

        public IBallPresenter CurrentAttachedBall
        {
            get
            {
                var pendulum = _presentersPool.GetPresenter<IPendulumPresenter>();
                return pendulum.CurrentAttachedBall;
            }
        }

        public void Attach(IBallPresenter ball)
        {
            var pendulum = _presentersPool.GetPresenter<IPendulumPresenter>();
            pendulum.AttachBall(ball);
        }

        public IBallPresenter Detach()
        {
            var pendulum = _presentersPool.GetPresenter<IPendulumPresenter>();
            return pendulum.DetachBall();
        }
    }
}