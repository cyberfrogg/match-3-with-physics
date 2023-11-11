using Game.Data;
using Game.Views.Ball;
using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Presenters.Ball
{
    public interface IBallPresenter : IPresenter<IBallView>, IInjectable
    {
        Vector3 Position { get; }
        EBallType Type { get; }
        bool IsKinematic { get; set; }
        void ResetLocalPosition();
        void Destroy();
    }
}