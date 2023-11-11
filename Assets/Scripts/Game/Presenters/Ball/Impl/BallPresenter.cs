using Game.Data;
using Game.Settings.Ball;
using Game.Views.Ball;
using UnityEngine;
using Zenject;

namespace Game.Presenters.Ball.Impl
{
    public class BallPresenter : IBallPresenter
    {
        [Inject] private readonly IBallParameters _ballParameters;

        public BallPresenter(
            IBallView view,
            EBallType ballType
            )
        {
            Type = ballType;
            View = view;
        }
        
        public IBallView View { get; }
        public EBallType Type { get; }

        public void OnInject()
        {
            var color = _ballParameters.GetColorByType(Type);
            View.SetColor(color);
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