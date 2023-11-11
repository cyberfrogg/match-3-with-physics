using Game.Data;

namespace Game.Services.Score
{
    public interface IScoreService
    {
        void AddScoreForBall(EBallType ballType);
    }
}