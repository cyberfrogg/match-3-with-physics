using Zenject;

namespace Loading.Installers
{
    public class LoadingManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingManager>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}