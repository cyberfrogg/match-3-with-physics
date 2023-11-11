using System.Collections.Generic;
using Game.Views.Column.Impl;
using Game.Views.Input;
using Game.Views.Input.Impl;
using Game.Views.Pendulum;
using Game.Views.Pendulum.Impl;
using Game.Views.ResultScreen;
using Game.Views.ResultScreen.Impl;
using UnityEngine;

namespace Game.Data
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private List<ColumnView> columnViews;
        [SerializeField] private PendulumView pendulumView;
        
        [Header("UI:")]
        [SerializeField] private InputView inputView;
        [SerializeField] private ResultScreenView resultScreenView;

        public List<ColumnView> ColumnViews => columnViews;
        public IPendulumView PendulumView => pendulumView;
        public IInputView InputView => inputView;
        public IResultScreenView ResultScreenView => resultScreenView;
    }
}