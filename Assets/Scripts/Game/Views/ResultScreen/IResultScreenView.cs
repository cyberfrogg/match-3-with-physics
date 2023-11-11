using System;
using ProtoYeet.Abstracts;

namespace Game.Views.ResultScreen
{
    public interface IResultScreenView : IView
    {
        event Action MenuPressedEvent;
        event Action ReplayPressedEvent;
        void Toggle(bool isEnabled);
        void SetScore(int score);
    }
}