using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Ball
{
    public interface IBallView : IView
    {
        void SetColor(Color color);
        bool IsKinematic { get; set; }
    }
}