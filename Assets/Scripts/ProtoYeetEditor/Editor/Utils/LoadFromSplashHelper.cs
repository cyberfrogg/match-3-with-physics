using UnityEditor;
using UnityEditor.SceneManagement;

namespace ProtoYeetEditor.Editor.Utils
{
    
    public static class LoadFromSplashHelper
    {
        [MenuItem("Tools/Load From Splash")]
        public static void LoadFromSplash()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity", OpenSceneMode.Single);
            EditorApplication.EnterPlaymode();
        }
    }
}