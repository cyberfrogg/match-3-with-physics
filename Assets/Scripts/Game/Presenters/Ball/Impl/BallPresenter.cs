using Game.Views.Ball;
using UnityEngine;

namespace Game.Presenters.Ball.Impl
{
    public class BallPresenter : IBallPresenter
    {
        public IBallView View { get; }

        public BallPresenter(
            IBallView view
            )
        {
            View = view;
        }

        public void OnInject()
        {
            
        }

        public bool IsKinematic
        {
            get => View.IsKinematic;
            set => View.IsKinematic = value;
        }

        public void ResetLocalPosition()
        {
            View.Transform.localPosition = Vector3.zero;
        }
    }
}