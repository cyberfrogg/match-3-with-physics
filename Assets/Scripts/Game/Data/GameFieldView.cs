using System.Collections.Generic;
using Game.Views.Column.Impl;
using Game.Views.Pendulum;
using Game.Views.Pendulum.Impl;
using UnityEngine;

namespace Game.Data
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private List<ColumnView> columnViews;
        [SerializeField] private PendulumView pendulumView;

        public List<ColumnView> ColumnViews => columnViews;
        public IPendulumView PendulumView => pendulumView;
    }
}