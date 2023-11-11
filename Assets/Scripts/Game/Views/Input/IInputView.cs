using System;

namespace Game.Views.Input
{
    public interface IInputView
    {
        event Action OnTap;
    }
}