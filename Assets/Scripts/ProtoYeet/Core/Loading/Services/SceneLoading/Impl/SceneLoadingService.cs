using UnityEngine.SceneManagement;

namespace ProtoYeet.Core.Loading.Services.SceneLoading.Impl
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}