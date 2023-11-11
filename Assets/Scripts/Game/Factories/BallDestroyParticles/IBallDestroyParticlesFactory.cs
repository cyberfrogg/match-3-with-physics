using Game.Presenters.BallDestroyParticles;

namespace Game.Factories.BallDestroyParticles
{
    public interface IBallDestroyParticlesFactory
    {
        IBallDestroyParticlesPresenter Create();
    }
}