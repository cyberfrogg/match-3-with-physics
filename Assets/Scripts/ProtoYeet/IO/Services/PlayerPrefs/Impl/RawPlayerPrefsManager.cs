namespace ProtoYeet.IO.Services.PlayerPrefs.Impl
{
    public class RawPlayerPrefsManager : IPlayerPrefsManager
    {
        public void Save()
        {
            UnityEngine.PlayerPrefs.Save();
        }
        
        public void Clear()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }

        public void SetValue<T>(string key, T value)
        {
            switch (value)
            {
                case string stringValue:
                    UnityEngine.PlayerPrefs.SetString(key, stringValue);
                    break;
                case int intValue:
                    UnityEngine.PlayerPrefs.SetInt(key, intValue);
                    break;
                case float floatValue:
                    UnityEngine.PlayerPrefs.SetFloat(key, floatValue);
                    break;
            }
        }

        public void GetValue<T>(string key, T defaultValue)
        {
            switch (defaultValue)
            {
                case string stringValue:
                    UnityEngine.PlayerPrefs.GetString(key, stringValue);
                    break;
                case int intValue:
                    UnityEngine.PlayerPrefs.GetInt(key, intValue);
                    break;
                case float floatValue:
                    UnityEngine.PlayerPrefs.GetFloat(key, floatValue);
                    break;
            }
        }
    }
}