using Game.Presenters.ResultScreen;
using Game.Views.ResultScreen;

namespace Game.Factories.ResultScreen
{
    public interface IResultScreenFactory
    {
        IResultScreenPresenter Create(IResultScreenView view);
    }
}