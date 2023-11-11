using Game.Views.Ball;
using ProtoYeet.Abstracts;

namespace Game.Presenters.Ball
{
    public interface IBallPresenter : IPresenter<IBallView>, IInjectable
    {
        bool IsKinematic { get; set; }
        void ResetLocalPosition();
    }
}