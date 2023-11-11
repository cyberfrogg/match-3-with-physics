using Game.Data;

namespace Game.Db.Prefabs
{
    public interface IPrefabsBase
    {
        public PrefabsBaseItem GetPrefab(string prefabName);
    }
}