using System;
using UnityEngine;

namespace Game.Data
{
    [Serializable]
    public struct BallVo
    {
        public EBallType BallType;
        public Color Color;
        public int Score;
    }
}