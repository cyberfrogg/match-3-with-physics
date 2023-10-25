
using ProtoYeet.Abstracts;
using Zenject;

namespace ProtoYeet.Core.Factory
{
    public static class FactoryUtils
    {
        public static void Inject(DiContainer container, IInjectable target)
        {
            container.Inject(target);
            target.OnInject();
        }
    }
}