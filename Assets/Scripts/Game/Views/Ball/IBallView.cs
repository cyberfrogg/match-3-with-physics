using System;
using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Ball
{
    public interface IBallView : IView
    {
        event Action OnCollisionEnterEvent;
        void SetColor(Color color);
        bool IsKinematic { get; set; }
    }
}