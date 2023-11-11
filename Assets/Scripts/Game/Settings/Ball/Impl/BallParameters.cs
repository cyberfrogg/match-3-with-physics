using System;
using System.Collections.Generic;
using Game.Data;
using UnityEngine;

namespace Game.Settings.Ball.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BallParameters), fileName = nameof(BallParameters))]
    public class BallParameters : ScriptableObject, IBallParameters
    {
        [SerializeField] private List<BallColorByBallTypeItem> ballColorByBallTypeItems;
        
        public Color GetColorByType(EBallType type)
        {
            foreach (var item in ballColorByBallTypeItems)
            {
                if (item.BallType == type)
                {
                    return item.Color;
                }
            }

            throw new NullReferenceException($"Color not found for type: {type}");
        }
    }
}