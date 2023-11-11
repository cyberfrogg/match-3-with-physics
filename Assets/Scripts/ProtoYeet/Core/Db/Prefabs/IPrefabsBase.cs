using ProtoYeet.Core.Data;

namespace ProtoYeet.Core.Db.Prefabs
{
    public interface IPrefabsBase
    {
        public PrefabsBaseItem GetPrefab(string prefabName);
    }
}