using Game.Presenters.Pendulum;
using Game.Views.Pendulum;

namespace Game.Factories.Pendulum
{
    public interface IPendulumFactory
    {
        IPendulumPresenter Create(IPendulumView pendulumView);
    }
}