using UnityEngine;

namespace Game.Settings.Pendulum.Impl
{
    [CreateAssetMenu(fileName = nameof(PendulumParameters), menuName = "Settings/" + nameof(PendulumParameters))]
    public class PendulumParameters : ScriptableObject, IPendulumParameters
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float rotationAmplitude;
        [SerializeField] private float ballSpawnDelay;

        public float RotationSpeed => rotationSpeed;
        public float RotationAmplitude => rotationAmplitude;
        public float BallSpawnDelay => ballSpawnDelay;
    }
}