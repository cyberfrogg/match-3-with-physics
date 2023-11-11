using ProtoYeet.Abstracts;

namespace Game.Views.Ball
{
    public interface IBallView : IView
    {
        bool IsKinematic { get; set; }
    }
}