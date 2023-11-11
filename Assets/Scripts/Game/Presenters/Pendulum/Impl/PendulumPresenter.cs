using Game.Presenters.Ball;
using Game.Views.Pendulum;
using ProtoYeet.Core.Systems;
using UnityEngine;

namespace Game.Presenters.Pendulum.Impl
{
    public class PendulumPresenter : IPendulumPresenter, IUpdateSystem
    {
        public IPendulumView View { get; }

        public PendulumPresenter(
            IPendulumView view
            )
        {
            View = view;
        }

        public void OnInject()
        {
            
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
        
        public void Update()
        {
            var time = Time.time;
            var rotateValue = Mathf.Sin(time * View.RotateAnimationSpeed);

            View.PendulumRotation = rotateValue;
        }
    }
}