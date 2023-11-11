using Game.Presenters.BallDestroyParticles;

namespace Game.Factories.BallDestroyParticlesFactory
{
    public interface IBallDestroyParticlesFactory
    {
        IBallDestroyParticlesPresenter Create();
    }
}