using Game.Settings.Ball.Impl;
using Game.Settings.Pendulum.Impl;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class GameSettingsInstaller : MonoInstaller
    {
        [SerializeField] private PendulumParameters pendulumParameters;
        [SerializeField] private BallParameters ballParameters;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PendulumParameters>().FromInstance(pendulumParameters).AsSingle();
            Container.BindInterfacesAndSelfTo<BallParameters>().FromInstance(ballParameters).AsSingle();
        }
    }
}