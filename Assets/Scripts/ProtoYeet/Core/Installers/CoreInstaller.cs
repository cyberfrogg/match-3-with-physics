using ProtoYeet.Core.Services.PrefabSpawn.Impl;
using ProtoYeet.Core.Services.PresentersPool.Impl;
using ProtoYeet.Core.Services.Scheduler.Impl;
using Zenject;

namespace ProtoYeet.Core.Installers
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PrefabSpawnService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PresentersPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<SchedulerService>().AsSingle();
        }
    }
}