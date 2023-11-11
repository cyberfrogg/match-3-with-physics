using System;
using System.Collections.Generic;
using Game.Data;
using UnityEngine;

namespace Game.Settings.Ball.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BallParameters), fileName = nameof(BallParameters))]
    public class BallParameters : ScriptableObject, IBallParameters
    {
        [SerializeField] private List<BallVo> ballColorByBallTypeItems;
        
        public BallVo GetBallVo(EBallType type)
        {
            foreach (var item in ballColorByBallTypeItems)
            {
                if (item.BallType == type)
                {
                    return item;
                }
            }

            throw new NullReferenceException($"Color not found for type: {type}");
        }
    }
}