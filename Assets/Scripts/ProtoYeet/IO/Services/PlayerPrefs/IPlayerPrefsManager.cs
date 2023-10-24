namespace ProtoYeet.IO.Services.PlayerPrefs
{
    public interface IPlayerPrefsManager
    {
        void Save();
        void Clear();
        void SetValue<T>(string key, T value);
        void DeleteKey(string key);
        T GetValue<T>(string key, T defaultValue);
    }
}