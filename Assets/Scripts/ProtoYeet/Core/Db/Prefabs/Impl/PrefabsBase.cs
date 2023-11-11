using System;
using System.Collections.Generic;
using ProtoYeet.Core.Data;
using UnityEngine;

namespace ProtoYeet.Core.Db.Prefabs.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PrefabsBase), fileName = nameof(PrefabsBase))]
    public class PrefabsBase : ScriptableObject, IPrefabsBase
    {
        [SerializeField] private List<PrefabsBaseItem> items;
        
        public PrefabsBaseItem GetPrefab(string prefabName)
        {
            foreach (var item in items)
            {
                if (item.Name == prefabName)
                {
                    return item;
                }
            }

            throw new NullReferenceException();
        }
    }
}