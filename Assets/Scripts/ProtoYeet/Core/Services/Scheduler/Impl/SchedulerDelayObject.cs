using System;
using UnityEngine;

namespace ProtoYeet.Core.Services.Scheduler.Impl
{
    public class SchedulerDelayObject : MonoBehaviour
    {
        private float _delayTime;
        private float _currentTime;
        private bool _isComplete;
        private Action _onComplete;
        
        public void Delay(Action onComplete, float time)
        {
            _onComplete = onComplete;
            _delayTime = time;
            _currentTime = 0;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _delayTime && !_isComplete)
            {
                _isComplete = true;
                _onComplete?.Invoke();
            }
        }
    }
}