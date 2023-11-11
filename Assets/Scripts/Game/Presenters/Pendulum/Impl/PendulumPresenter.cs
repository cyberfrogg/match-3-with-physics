using Game.Presenters.Ball;
using Game.Settings.Pendulum;
using Game.Views.Pendulum;
using UnityEngine;
using Zenject;

namespace Game.Presenters.Pendulum.Impl
{
    public class PendulumPresenter : IPendulumPresenter
    {
        [Inject] private readonly IPendulumParameters _pendulumParameters;
        public IPendulumView View { get; }
        
        
        public PendulumPresenter(
            IPendulumView view
            )
        {
            View = view;
        }

        public void OnInject()
        {
            View.UpdateEvent += OnUpdate;
            View.OnDestroyEvent += OnDestroy;
        }

        private void OnDestroy()
        {
            View.UpdateEvent -= OnUpdate;
            View.OnDestroyEvent -= OnDestroy;
        }

        public void AttachBall(IBallPresenter ballPresenter)
        {
            ballPresenter.View.Transform.SetParent(View.AttachParent);
            ballPresenter.IsKinematic = true;
            ballPresenter.ResetLocalPosition();
            CurrentAttachedBall = ballPresenter;
        }

        public IBallPresenter DetachBall()
        {
            var ball = CurrentAttachedBall;
            CurrentAttachedBall = null;
            
            ball.View.Transform.SetParent(null);
            ball.IsKinematic = false;
            return ball;
        }

        public IBallPresenter CurrentAttachedBall { get; private set; }

        private void OnUpdate()
        {
            var time = Time.time;
            var rotateValue = Mathf.Sin(time * _pendulumParameters.RotationSpeed) * _pendulumParameters.RotationAmplitude;

            View.PendulumRotation = rotateValue;
        }
    }
}