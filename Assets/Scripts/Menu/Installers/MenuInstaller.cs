using Menu.Services.Impl;
using Zenject;

namespace Menu.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuLoadLevelsService>().AsSingle();
        }
    }
}
