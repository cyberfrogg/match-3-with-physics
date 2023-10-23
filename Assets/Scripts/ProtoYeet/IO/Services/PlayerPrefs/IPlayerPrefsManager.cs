namespace ProtoYeet.IO.Services.PlayerPrefs
{
    public interface IPlayerPrefsManager
    {
        void Save();
        void Clear();
        void SetValue<T>(string key, T value);
        T GetValue<T>(string key, T defaultValue);
    }
}