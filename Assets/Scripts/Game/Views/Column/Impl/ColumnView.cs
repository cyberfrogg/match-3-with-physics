using System.Collections.Generic;
using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Column.Impl
{
    public class ColumnView : MonoView, IColumnView
    {
        [SerializeField] private List<Transform> cells;

        public List<Vector3> Cells
        {
            get
            {
                var cellsPos = new List<Vector3>();
                foreach (var cell in cells)
                {
                    cellsPos.Add(cell.position);
                }

                return cellsPos;
            }
        }
    }
}