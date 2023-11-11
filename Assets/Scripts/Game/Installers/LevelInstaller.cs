using Game.Data;
using Game.Factories.Ball;
using Game.Factories.Ball.Impl;
using Game.Factories.BallDestroyParticles;
using Game.Factories.BallDestroyParticles.Impl;
using Game.Factories.Column;
using Game.Factories.Column.Impl;
using Game.Factories.Pendulum;
using Game.Factories.Pendulum.Impl;
using Game.Factories.ResultScreen;
using Game.Factories.ResultScreen.Impl;
using Game.Providers.GameFieldProvider;
using Game.Providers.GameFieldProvider.Impl;
using Game.Services.BallsRowMatch.Impl;
using Game.Services.InputService.Impl;
using Game.Services.PendulumAttach.Impl;
using Game.Services.Score.Impl;
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
            BindServices();
            BindSystems();
        }


        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<PendulumAttachService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallsRowMatchService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle();
        }
        
        private void BindFactories()
        {
            Container.Bind<IColumnFactory>().To<ColumnFactory>().AsSingle();
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();
            Container.Bind<IPendulumFactory>().To<PendulumFactory>().AsSingle();
            Container.Bind<IBallDestroyParticlesFactory>().To<BallDestroyParticlesFactory>().AsSingle();
            Container.Bind<IResultScreenFactory>().To<ResultScreenViewFactory>().AsSingle();
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
            Container.BindInterfacesAndSelfTo<DetachOnTapSystem>().AsSingle();
        }
    }
}