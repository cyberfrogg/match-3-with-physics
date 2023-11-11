using Game.Data;
using Game.Services.BallsRowMatch;
using Game.Settings.Ball;
using Game.Views.Ball;
using ProtoYeet.Core.Services.PresentersPool;
using UnityEngine;
using Zenject;

namespace Game.Presenters.Ball.Impl
{
    public class BallPresenter : IBallPresenter
    {
        [Inject] private readonly IBallParameters _ballParameters;
        [Inject] private readonly IBallsRowMatchService _ballsRowMatchService;
        [Inject] private readonly IPresentersPool _presentersPool;

        public BallPresenter(
            IBallView view,
            EBallType ballType
            )
        {
            Type = ballType;
            View = view;
        }
        
        public IBallView View { get; }
        public Vector3 Position => View.Transform.position;
        public EBallType Type { get; }

        public void OnInject()
        {
            var color = _ballParameters.GetColorByType(Type);
            View.SetColor(color);

            View.OnCollisionEnterEvent += OnCollisionEnterEvent;

            View.OnDestroyEvent += OnDestroy;
        }

        private void OnCollisionEnterEvent()
        {
            _ballsRowMatchService.Check();
        }

        private void OnDestroy()
        {
            _presentersPool.Remove(this);
            View.OnDestroyEvent -= OnDestroy;
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

        public void Destroy()
        {
            View.DestroyView();
        }
    }
}