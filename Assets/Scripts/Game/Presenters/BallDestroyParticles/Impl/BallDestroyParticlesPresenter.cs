using Game.Views.BallDestroyParticles;
using ProtoYeet.Core.Services.PresentersPool;
using ProtoYeet.Core.Services.Scheduler;
using UnityEngine;
using Zenject;

namespace Game.Presenters.BallDestroyParticles.Impl
{
    public class BallDestroyParticlesPresenter : IBallDestroyParticlesPresenter
    {
        [Inject] private readonly ISchedulerService _schedulerService;
        [Inject] private readonly IPresentersPool _presentersPool;
        
        
        public BallDestroyParticlesPresenter(
            IBallDestroyParticlesView view
            )
        {
            View = view;
        }
        
        public IBallDestroyParticlesView View { get; }

        public void OnInject()
        {
            View.OnDestroyEvent += OnDestroy;
            
            _schedulerService.Delay(() =>
            {
                View.DestroyView();
            }, 2);
        }

        private void OnDestroy()
        {
            _presentersPool.Remove(this);
            View.OnDestroyEvent -= OnDestroy;
        }

        public Vector3 Position
        {
            get => View.Transform.position;
            set
            {
                View.Transform.position = value;
            }
        }
    }
}