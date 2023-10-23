using ProtoYeet.IO.Services.PlayerPrefs.Impl;
using Zenject;

namespace ProtoYeet.IO.Installers
{
    public class IOInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RawPlayerPrefsManager>().AsSingle();
        }
    }
}