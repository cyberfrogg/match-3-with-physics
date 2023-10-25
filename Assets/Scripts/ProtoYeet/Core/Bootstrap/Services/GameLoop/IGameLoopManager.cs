using ProtoYeet.Core.Systems;

namespace ProtoYeet.Core.Bootstrap.Services.GameLoop
{
    public interface IGameLoopManager
    {
        void AddUpdateListener(IUpdateSystem updateSystem);
        void RemoveUpdateListener(IUpdateSystem updateSystem);
    }
}