using System;
using UnityEngine;

namespace ProtoYeet.Ui.Abstracts
{
    public abstract class AButton : MonoBehaviour
    {
        public event Action Click;

        protected void InternalClick()
        {
            Click?.Invoke();
        }

        private void OnDestroy()
        {
            Click = null;
        }
    }
}