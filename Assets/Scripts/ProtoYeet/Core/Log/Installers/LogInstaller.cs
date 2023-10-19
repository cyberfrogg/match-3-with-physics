using ProtoYeet.Core.Log.Services.Impl;
using Zenject;

namespace ProtoYeet.Core.Log.Installers
{
    public class LogInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnityLoggerService>().AsSingle();
        }
    }
}