using ProtoYeet.Abstracts;
using TMPro;
using UnityEngine;

namespace Game.Views.ResultScreen.Impl
{
    public class ResultScreenView : MonoView, IResultScreenView
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private GameObject _visibilityGameObject;
        
        public void Toggle(bool isEnabled)
        {
            _visibilityGameObject.SetActive(isEnabled);
        }

        public void SetScore(int score)
        {
            _score.text = $"{score}";
        }
    }
}