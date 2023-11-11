using System.Collections.Generic;
using System.Linq;
using Game.Presenters.Ball;
using Game.Presenters.Column;
using ProtoYeet.Core.Services.PresentersPool;
using UnityEngine;

namespace Game.Services.BallsRowMatch.Impl
{
    public class BallsRowMatchService : IBallsRowMatchService
    {
        private readonly IPresentersPool _presentersPool;

        public BallsRowMatchService(
            IPresentersPool presentersPool
            )
        {
            _presentersPool = presentersPool;
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
            
        }

        private List<List<Vector3>> ColumnsToRows(List<IColumnPresenter> columns)
        {
            var rowsCount = columns[0].Cells.Count;
            var rows = new List<List<Vector3>>();
            
            for (var i = 0; i < columns.Count; i++)
            {
                var row = new List<Vector3>();
                for (var j = 0; j < rowsCount; j++)
                {
                    row.Add(columns[i].Cells[j]);
                }
                
                rows.Add(row);
            }

            return rows;
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
            ball.Destroy();
        }
    }
}