using System;
using UnityEngine;

namespace ProtoYeet.Abstracts
{
    public interface IView
    {
        event Action UpdateEvent;
        Transform Transform { get; } 
        event Action OnDestroyEvent;
        public void DestroyView();
    }
}