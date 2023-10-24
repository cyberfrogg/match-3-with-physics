using Game.Views.Player.Impl;
using UnityEngine;

namespace Game.Data
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;

        public PlayerView PlayerView => playerView;
    }
}