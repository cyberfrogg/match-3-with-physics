using Game.Data;
using Game.Views.Ball;
using ProtoYeet.Abstracts;

namespace Game.Presenters.Ball
{
    public interface IBallPresenter : IPresenter<IBallView>, IInjectable
    {
        public EBallType Type { get; }
        bool IsKinematic { get; set; }
        void ResetLocalPosition();
    }
}