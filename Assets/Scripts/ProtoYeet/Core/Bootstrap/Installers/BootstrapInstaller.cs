using ProtoYeet.Core.Bootstrap.Services.GameLoop.Impl;
using Zenject;

namespace ProtoYeet.Core.Bootstrap.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameLoopManager>().AsSingle().NonLazy();
        }
    }
}