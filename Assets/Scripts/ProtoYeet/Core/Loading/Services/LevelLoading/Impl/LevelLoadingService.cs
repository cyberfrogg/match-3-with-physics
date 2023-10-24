using ProtoYeet.Core.Loading.Services.SceneLoading;
using ProtoYeet.IO.Services.PlayerPrefs;

namespace ProtoYeet.Core.Loading.Services.LevelLoading.Impl
{
    public class LevelLoadingService : ILevelLoadingService
    {
        private readonly IPlayerPrefsManager _playerPrefsManager;
        private readonly ISceneLoadingService _sceneLoadingService;

        private string _nextLevelToLoad;

        public LevelLoadingService(
            IPlayerPrefsManager playerPrefsManager,
            ISceneLoadingService sceneLoadingService
            )
        {
            _playerPrefsManager = playerPrefsManager;
            _sceneLoadingService = sceneLoadingService;
        }

        public string NextLevelToLoad
        {
            get => _playerPrefsManager.GetValue("nextLevel", "Splash");
            set
            {
                _nextLevelToLoad = value;
                _playerPrefsManager.SetValue("nextLevel", _nextLevelToLoad);
            }
        }

        public void Load(string levelName)
        {
            NextLevelToLoad = levelName;
            _sceneLoadingService.LoadScene("Loading");
        }
    }
}