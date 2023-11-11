namespace Game.Settings.Pendulum
{
    public interface IPendulumParameters
    {
        float RotationSpeed { get; }
        float RotationAmplitude { get; }
        float BallSpawnDelay { get; }
    }
}