using System;
using ProtoYeet.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views.ResultScreen.Impl
{
    public class ResultScreenView : MonoView, IResultScreenView
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private GameObject _visibilityGameObject;
        [SerializeField] private Button _replayButton;
        [SerializeField] private Button _menuButton;

        public event Action MenuPressedEvent;
        public event Action ReplayPressedEvent;
        
        private void Awake()
        {
            _menuButton.onClick.AddListener(OnMenuButtonClick);
            _replayButton.onClick.AddListener(OnReplayButtonClick);
        }

        public void Toggle(bool isEnabled)
        {
            _visibilityGameObject.SetActive(isEnabled);
        }

        public void SetScore(int score)
        {
            _score.text = $"{score}";
        }

        private void OnMenuButtonClick()
        {
            MenuPressedEvent?.Invoke();
        }
        private void OnReplayButtonClick()
        {
            ReplayPressedEvent?.Invoke();
        }

        public override void DestroyView()
        {
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
            _replayButton.onClick.RemoveListener(OnReplayButtonClick);
            
            base.DestroyView();
        }
    }
}