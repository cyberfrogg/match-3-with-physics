using ProtoYeet.Abstracts;

namespace ProtoYeet.Core.Services.PrefabSpawn
{
    public interface IPrefabSpawnService
    {
        T Spawn<T>(string name) where T : IView;
    }
}