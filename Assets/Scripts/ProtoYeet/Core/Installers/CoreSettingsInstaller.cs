using ProtoYeet.Core.Db.Prefabs;
using ProtoYeet.Core.Db.Prefabs.Impl;
using UnityEngine;
using Zenject;

namespace ProtoYeet.Core.Installers
{
    public class CoreSettingsInstaller : MonoInstaller
    {
        [SerializeField] private PrefabsBase prefabsBase;
        
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IPrefabsBase>().FromInstance(prefabsBase).AsSingle();
        }
    }
}