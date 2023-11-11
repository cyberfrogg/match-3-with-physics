using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Views.Input.Impl
{
    public class InputView : MonoBehaviour, IInputView, IPointerDownHandler
    {
        public event Action OnTap;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnTap?.Invoke();
        }
    }
}