namespace ProtoYeet.Core.Loading.Services.LevelLoading
{
    public interface ILevelLoadingService
    {
        string NextLevelToLoad { get; }
        void Load(string levelName);
    }
}