using Game.Settings.Pendulum.Impl;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class GameSettingsInstaller : MonoInstaller
    {
        [SerializeField] private PendulumParameters pendulumParameters;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PendulumParameters>().FromInstance(pendulumParameters).AsSingle();
        }
    }
}