using Game.Data;

namespace Game.Services.Score
{
    public interface IScoreService
    {
        int Score { get; }
        void AddScoreForBall(EBallType ballType);
    }
}