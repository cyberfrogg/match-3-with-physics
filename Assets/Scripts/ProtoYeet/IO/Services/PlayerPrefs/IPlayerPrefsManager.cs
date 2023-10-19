namespace ProtoYeet.IO.Services.PlayerPrefs
{
    public interface IPlayerPrefsManager
    {
        void Save();
        void Clear();
        void SetValue<T>(string key, T value);
        void GetValue<T>(string key, T defaultValue);
    }
}