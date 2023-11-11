using System;
using UnityEngine;

namespace ProtoYeet.Abstracts
{
    public abstract class MonoView : MonoBehaviour, IView
    {
        public event Action UpdateEvent;
        
        public Transform Transform => transform;
        
        public event Action OnDestroyEvent;

        protected void InternalInvokeOnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }

        private void OnDestroy()
        {
            InternalInvokeOnDestroy();
        }

        public virtual void DestroyView()
        {
            InternalInvokeOnDestroy();
            Destroy(gameObject);
        }

        private void Update()
        {
            UpdateEvent?.Invoke();
        }
    }
}