using System.Collections.Generic;
using System.Linq;
using Game.Factories.BallDestroyParticlesFactory;
using Game.Presenters.Ball;
using Game.Presenters.Column;
using Game.Services.Score;
using ProtoYeet.Core.Services.PresentersPool;
using UnityEngine;

namespace Game.Services.BallsRowMatch.Impl
{
    public class BallsRowMatchService : IBallsRowMatchService
    {
        private readonly IPresentersPool _presentersPool;
        private readonly IBallDestroyParticlesFactory _ballDestroyParticlesFactory;
        private readonly IScoreService _scoreService;

        public BallsRowMatchService(
            IPresentersPool presentersPool,
            IBallDestroyParticlesFactory ballDestroyParticlesFactory,
            IScoreService scoreService
            )
        {
            _presentersPool = presentersPool;
            _ballDestroyParticlesFactory = ballDestroyParticlesFactory;
            _scoreService = scoreService;
        }

        public void Check()
        {
            CheckDiagonalMatch();
            CheckHorizontalMatch();
            CheckVerticalMatch();
        }

        private void CheckHorizontalMatch()
        {
            var balls = _presentersPool.GetPresenters<IBallPresenter>();
            var columns = _presentersPool.GetPresenters<IColumnPresenter>();

            foreach (var columnIndex in Enumerable.Range(0, columns[0].Cells.Count)) // Assuming all columns have the same number of cells
            {
                var ballsInRow = new List<IBallPresenter>();

                foreach (var column in columns)
                {
                    var cell = column.Cells[columnIndex];
                    var ball = GetBallOnPosition(balls, cell);

                    if (ball != null)
                    {
                        ballsInRow.Add(ball);
                    }
                }

                if (ballsInRow.Count == columns.Count)
                {
                    var type = ballsInRow.First().Type;
                    var isSameTypeAll = ballsInRow.All(x => x.Type == type);

                    if (isSameTypeAll)
                    {
                        foreach (var ball in ballsInRow)
                        {
                            DestroyBall(ball);
                        }
                        return; // Assuming you want to stop after destroying the first matching row
                    }
                }
            }
        }
        
        private void CheckVerticalMatch()
        {
            var balls = _presentersPool.GetPresenters<IBallPresenter>();
            var columns = _presentersPool.GetPresenters<IColumnPresenter>();
            
            foreach (var column in columns)
            {
                var ballsInColumn = new List<IBallPresenter>();
                
                foreach (var cell in column.Cells)
                {
                    var ball = GetBallOnPosition(balls, cell);
                    if (ball != null)
                    {
                        ballsInColumn.Add(ball);
                    }
                }

                if (ballsInColumn.Count == column.Cells.Count)
                {
                    var type = ballsInColumn.First().Type;
                    var isSameTypeAll = ballsInColumn.All(x => x.Type == type);

                    if (isSameTypeAll)
                    {
                        foreach (var ball in ballsInColumn)
                        {
                            DestroyBall(ball);
                        }
                        return;
                    }
                }
            }
        }
        
        private void CheckDiagonalMatch()
        {
            var balls = _presentersPool.GetPresenters<IBallPresenter>();
            var columns = _presentersPool.GetPresenters<IColumnPresenter>();

            var numRows = columns[0].Cells.Count;

            for (var startColumn = 0; startColumn < columns.Count; startColumn++)
            {
                var ballsInDiagonal = new List<IBallPresenter>();

                for (var i = 0; i < columns.Count && (startColumn + i) < columns.Count; i++)
                {
                    var columnIndex = startColumn + i;
                    var cell = columns[columnIndex].Cells[i];

                    var ball = GetBallOnPosition(balls, cell);

                    if (ball != null)
                    {
                        ballsInDiagonal.Add(ball);
                    }
                    else
                    {
                        ballsInDiagonal.Clear();
                    }
                }

                ProcessDiagonalMatch(ballsInDiagonal, columns);
            }

            for (var startColumn = columns.Count - 1; startColumn >= 0; startColumn--)
            {
                var ballsInDiagonal = new List<IBallPresenter>();

                for (var i = 0; i < columns.Count && (startColumn - i) >= 0; i++)
                {
                    var columnIndex = startColumn - i;
                    var cell = columns[columnIndex].Cells[i];

                    var ball = GetBallOnPosition(balls, cell);

                    if (ball != null)
                    {
                        ballsInDiagonal.Add(ball);
                    }
                    else
                    {
                        ballsInDiagonal.Clear();
                    }
                }

                ProcessDiagonalMatch(ballsInDiagonal, columns);
            }
        }

        private void ProcessDiagonalMatch(List<IBallPresenter> ballsInDiagonal, List<IColumnPresenter> columns)
        {
            if (ballsInDiagonal.Count == columns.Count)
            {
                var type = ballsInDiagonal.First().Type;
                var isSameTypeAll = ballsInDiagonal.All(x => x.Type == type);

                if (isSameTypeAll)
                {
                    foreach (var ball in ballsInDiagonal)
                    {
                        DestroyBall(ball);
                    }
                }
            }
        }

        
        private IBallPresenter GetBallOnPosition(List<IBallPresenter> balls, Vector3 origin)
        {
            foreach (var ball in balls)
            {
                var distance = Vector3.Distance(ball.Position, origin);
                if (distance <= 0.4f)
                {
                    return ball;
                }
            }

            return null;
        }
        private void DestroyBall(IBallPresenter ball)
        {
            var destroyParticles = _ballDestroyParticlesFactory.Create();
            destroyParticles.Position = ball.Position;
            
            _scoreService.AddScoreForBall(ball.Type);
            
            ball.Destroy();
        }
    }
}