using System;
using UnityEngine;

namespace ProtoYeet.Abstracts
{
    public interface IView
    {
        Transform Transform { get; } 
        event Action OnDestroyEvent;
        public void DestroyView();
    }
}