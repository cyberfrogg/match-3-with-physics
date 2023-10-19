using Menu.Ui.MenuScreen;
using UnityEngine;
using Zenject;

namespace Menu.Installers
{
    public class MenuUiInstaller : MonoInstaller
    {
        [SerializeField] private MenuScreenView _menuScreenView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuScreenView>().FromInstance(_menuScreenView).AsSingle();
        }
    }
}