using System.Collections.Generic;
using ProtoYeet.Abstracts;

namespace ProtoYeet.Core.Services.PresentersPool
{
    public interface IPresentersPool
    {
        List<IPresenter<IView>> AllPresenters { get; }
            
        void Add(IPresenter<IView> presenter);
        void Remove(IPresenter<IView> presenter);
        
        List<T> GetPresenters<T>();
        T GetPresenter<T>();
    }
}