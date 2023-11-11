using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Ball.Impl
{
    public class BallView : MonoView, IBallView
    {
        [SerializeField] private Rigidbody2D rigidbody;

        public bool IsKinematic
        {
            get => rigidbody.isKinematic;
            set => rigidbody.isKinematic = value;
        }
    }
}