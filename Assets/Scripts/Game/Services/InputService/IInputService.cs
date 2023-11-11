using System;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        event Action OnTap;
    }
}