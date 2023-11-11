using Game.Presenters.Column;
using Game.Views.Column;

namespace Game.Factories.Column
{
    public interface IColumnFactory
    {
        IColumnPresenter Create(IColumnView columnView);
    }
}