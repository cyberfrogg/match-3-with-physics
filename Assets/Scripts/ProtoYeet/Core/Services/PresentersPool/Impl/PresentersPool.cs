using System;
using System.Collections.Generic;
using ProtoYeet.Abstracts;

namespace ProtoYeet.Core.Services.PresentersPool.Impl
{
    public class PresentersPool : IPresentersPool
    {
        private readonly List<IPresenter<IView>> _presenters = new ();

        public void Add(IPresenter<IView> presenter)
        {
            _presenters.Add(presenter);
        }

        public void Remove(IPresenter<IView> presenter)
        {
            _presenters.Remove(presenter);
        }

        public List<T> GetPresenters<T>()
        {
            var found = new List<T>();
            
            foreach (var presenterItem in _presenters)
            {
                if (presenterItem is T presenter)
                {
                    found.Add(presenter);
                }
            }

            return found;
        }

        public T GetPresenter<T>()
        {
            var presenters = GetPresenters<T>();

            if (presenters.Count == 0)
                throw new NullReferenceException($"Presenter [{typeof(T).Name}] not found");
            
            return presenters[0];
        }
    }
}