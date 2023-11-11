using System.Collections.Generic;
using Game.Views.Column;
using ProtoYeet.Core.Services.PresentersPool;
using UnityEngine;
using Zenject;

namespace Game.Presenters.Column.Impl
{
    public class ColumnPresenter : IColumnPresenter
    {
        [Inject] private readonly IPresentersPool _presentersPool;
        
        public IColumnView View { get; }
        
        public ColumnPresenter(
            IColumnView columnView
        )
        {
            View = columnView;
        }

        public void OnInject()
        {
            View.OnDestroyEvent += OnDestroy;
        }

        private void OnDestroy()
        {
            View.OnDestroyEvent -= OnDestroy;
            
            _presentersPool.Remove(this);
        }

        public List<Vector3> Cells => View.Cells;
    }
}