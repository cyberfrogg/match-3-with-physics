using Game.Factories.Ball;
using Game.Presenters.Pendulum;
using Game.Services.InputService;
using Game.Services.PendulumAttach;
using Game.Settings.Pendulum;
using ProtoYeet.Core.Services.PresentersPool;
using ProtoYeet.Core.Services.Scheduler;
using ProtoYeet.Core.Systems;

namespace Game.Systems
{
    public class DetachOnTapSystem : IInitializeSystem
    {
        private readonly IInputService _inputService;
        private readonly IPresentersPool _presentersPool;
        private readonly ISchedulerService _schedulerService;
        private readonly IPendulumParameters _pendulumParameters;
        private readonly IPendulumAttachService _pendulumAttachService;
        private readonly IBallFactory _ballFactory;

        public DetachOnTapSystem(
            IInputService inputService,
            IPresentersPool presentersPool,
            ISchedulerService schedulerService,
            IPendulumParameters pendulumParameters,
            IPendulumAttachService pendulumAttachService,
            IBallFactory ballFactory
            )
        {
            _inputService = inputService;
            _presentersPool = presentersPool;
            _schedulerService = schedulerService;
            _pendulumParameters = pendulumParameters;
            _pendulumAttachService = pendulumAttachService;
            _ballFactory = ballFactory;
        }

        public void Initialize()
        {
            _inputService.OnTap += OnTap;
        }

        private void OnTap()
        {
            var pendulum = _presentersPool.GetPresenter<IPendulumPresenter>();

            if (pendulum.CurrentAttachedBall != null)
            {
                pendulum.DetachBall();
                
                _schedulerService.Delay(() =>
                {
                    var ball = _ballFactory.Create();
                    _pendulumAttachService.Attach(ball);
                }, _pendulumParameters.BallSpawnDelay);
            }
        }
    }
}