using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Pendulum
{
    public interface IPendulumView : IView
    {
        Transform AttachParent { get; }
        float PendulumRotation { get; set; }
    }
}