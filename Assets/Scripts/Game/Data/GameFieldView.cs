using System.Collections.Generic;
using Game.Views.Column.Impl;
using UnityEngine;

namespace Game.Data
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private List<ColumnView> columnViews;

        public List<ColumnView> ColumnViews => columnViews;
    }
}