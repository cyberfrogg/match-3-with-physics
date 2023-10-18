using ProtoYeet.Core.Loading.Services.SceneLoading.Impl;
using Zenject;

namespace ProtoYeet.Core.Loading.Installers
{
    public class LoadingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoadingService>().AsSingle();
        }
    }
}