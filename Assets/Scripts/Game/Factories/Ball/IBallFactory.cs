using Game.Presenters.Ball;

namespace Game.Factories.Ball
{
    public interface IBallFactory 
    {
        IBallPresenter Create();
    }
}