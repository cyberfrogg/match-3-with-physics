using Game.Data;
using Game.Settings.Ball;

namespace Game.Services.Score.Impl
{
    public class ScoreService : IScoreService
    {
        private readonly IBallParameters _ballParameters;
        
        public int Score { get; private set; }

        public ScoreService(
            IBallParameters ballParameters
            )
        {
            _ballParameters = ballParameters;
        }

        public void AddScoreForBall(EBallType ballType)
        {
            var ballParameters = _ballParameters.GetBallVo(ballType);
            Score += ballParameters.Score;
        }
    }
}