using Game.Data;

namespace Game.Providers.GameFieldProvider
{
    public interface IGameFieldProvider
    {
        GameFieldView GameFieldView { get; set; }
    }
}