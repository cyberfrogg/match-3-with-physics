using System.Collections.Generic;
using Game.Views.Column;
using ProtoYeet.Core.Bootstrap.Services.GameLoop;
using ProtoYeet.Core.Log.Services;
using ProtoYeet.Core.Systems;
using UnityEngine;
using Zenject;

namespace Game.Presenters.Column.Impl
{
    public class ColumnPresenter : IColumnPresenter, IUpdateSystem
    {
        [Inject] private readonly ILoggerService _loggerService;
        [Inject] private readonly IGameLoopManager _gameLoopManager;
        
        public IColumnView View { get; }
        
        public ColumnPresenter(
            IColumnView columnView
        )
        {
            View = columnView;
        }

        public void Update()
        {
            
        }

        public void OnInject()
        {
            _gameLoopManager.AddUpdateListener(this);
            View.OnDestroyEvent += OnDestroyEvent;
        }

        private void OnDestroyEvent()
        {
            View.OnDestroyEvent -= OnDestroyEvent;
            _gameLoopManager.RemoveUpdateListener(this);
        }

        public List<Vector3> Cells => View.Cells;
    }
}