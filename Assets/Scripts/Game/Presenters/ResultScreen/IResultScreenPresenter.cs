using Game.Views.ResultScreen;
using ProtoYeet.Abstracts;

namespace Game.Presenters.ResultScreen
{
    public interface IResultScreenPresenter : IPresenter<IResultScreenView>, IInjectable
    {
        void Show();
    }
}