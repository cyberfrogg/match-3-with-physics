using Game.Data;
using UnityEngine;

namespace Game.Settings.Ball
{
    public interface IBallParameters
    {
        Color GetColorByType(EBallType type);
    }
}