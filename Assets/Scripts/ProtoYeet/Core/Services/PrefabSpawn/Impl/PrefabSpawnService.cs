using System;
using ProtoYeet.Abstracts;
using ProtoYeet.Core.Db.Prefabs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProtoYeet.Core.Services.PrefabSpawn.Impl
{
    public class PrefabSpawnService : IPrefabSpawnService
    {
        private readonly IPrefabsBase _prefabsBase;

        public PrefabSpawnService(
            IPrefabsBase prefabsBase
            )
        {
            _prefabsBase = prefabsBase;
        }

        public T Spawn<T>(string name) where T : IView
        {
            var prefab = _prefabsBase.GetPrefab(name);
            var instance = Instantiate(prefab.Prefab);

            var view = instance.GetComponent<T>();
            if (view == null)
                throw new NullReferenceException($"Failed to get component for View on [{prefab.Name}] for [{typeof(T).Name}]");

            return view;
        }

        private GameObject Instantiate(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }
    }
}