using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Pendulum.Impl
{
    public class PendulumView : MonoView, IPendulumView
    {
        [SerializeField] private Transform attachParent;
        [SerializeField] private Transform rotateAnchor;

        private float _pendulumRotation;
        
        public Transform AttachParent => attachParent;

        public float PendulumRotation
        {
            get => _pendulumRotation;
            set
            {
                _pendulumRotation = value;

                var currentRotation = rotateAnchor.transform.rotation.eulerAngles;
                currentRotation.z = _pendulumRotation;
                rotateAnchor.transform.rotation = Quaternion.Euler(currentRotation);
            }
        }
    }
}