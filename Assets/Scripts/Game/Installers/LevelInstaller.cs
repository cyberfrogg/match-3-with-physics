using Game.Data;
using Game.Factories.Column;
using Game.Factories.Column.Impl;
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
            Container.Bind<IColumnFactory>().To<ColumnFactory>().AsSingle();
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