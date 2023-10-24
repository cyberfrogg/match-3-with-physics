using Game.Data;
using Game.Factories.Player;
using Game.Factories.Player.Impl;
using Game.Providers.GameFieldProvider;
using Game.Providers.GameFieldProvider.Impl;
using Game.Systems;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameFieldView gameFieldView;

        public override void InstallBindings()
        {
            BindFactories();
            BindGameField();
            BindSystems();
        }


        private void BindFactories()
        {
            Container.Bind<IPlayerPresenterFactory>().To<PlayerPresenterFactory>().AsSingle();
        }
        
        private void BindGameField()
        {
            var fieldProvider = new GameFieldProvider
            {
                GameFieldView = gameFieldView
            };
            
            Container.Bind<IGameFieldProvider>().FromInstance(fieldProvider).AsSingle();
        }
        
        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<InitializeGameSystem>().AsSingle();
        }
    }
}