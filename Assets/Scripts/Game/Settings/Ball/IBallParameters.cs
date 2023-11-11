using Game.Data;

namespace Game.Settings.Ball
{
    public interface IBallParameters
    {
        BallVo GetBallVo(EBallType type);
    }
}