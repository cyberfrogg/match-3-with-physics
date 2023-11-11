using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Ball.Impl
{
    public class BallView : MonoView, IBallView
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public bool IsKinematic
        {
            get => rigidbody.isKinematic;
            set => rigidbody.isKinematic = value;
        }
    }
}