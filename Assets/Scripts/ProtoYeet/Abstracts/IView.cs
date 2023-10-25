using System;

namespace ProtoYeet.Abstracts
{
    public interface IView
    {
        event Action OnDestroyEvent;
        public void DestroyView();
    }
}