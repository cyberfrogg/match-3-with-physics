using ProtoYeet.IO.Services.PlayerPrefs;

namespace ProtoYeet.Core.Loading.Services.LevelLoading.Impl
{
    public class LevelLoadingService : ILevelLoadingService
    {
        private readonly IPlayerPrefsManager _playerPrefsManager;

        private string _nextLevelToLoad;

        public LevelLoadingService(
            IPlayerPrefsManager playerPrefsManager
            )
        {
            _playerPrefsManager = playerPrefsManager;
        }

        public string NextLevelToLoad
        {
            get => _playerPrefsManager.GetValue("nextLevel", "Splash");
            set
            {
                _nextLevelToLoad = value;
            }
        }

        public void Load(string levelName)
        {
            
        }
    }
}