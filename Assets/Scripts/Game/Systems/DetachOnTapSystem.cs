using Game.Presenters.Pendulum;
using Game.Services.InputService;
using ProtoYeet.Core.Services.PresentersPool;
using ProtoYeet.Core.Systems;

namespace Game.Systems
{
    public class DetachOnTapSystem : IInitializeSystem
    {
        private readonly IInputService _inputService;
        private readonly IPresentersPool _presentersPool;

        public DetachOnTapSystem(
            IInputService inputService,
            IPresentersPool presentersPool
            )
        {
            _inputService = inputService;
            _presentersPool = presentersPool;
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
            }
        }
    }
}