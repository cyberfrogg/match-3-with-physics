using ProtoYeet.Abstracts;

namespace Game.Views.ResultScreen
{
    public interface IResultScreenView : IView
    {
        void Toggle(bool isEnabled);
        void SetScore(int score);
    }
}