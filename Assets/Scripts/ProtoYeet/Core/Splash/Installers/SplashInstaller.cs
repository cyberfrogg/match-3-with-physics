using Zenject;

namespace ProtoYeet.Core.Splash.Installers
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SplashManager>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}