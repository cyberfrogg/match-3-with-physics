using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProtoYeet.Core.Services.Scheduler.Impl
{
    public class SchedulerService : ISchedulerService
    {
        public void Delay(Action onComplete, float time)
        {
            var schedulerObject = new GameObject();
            var delayObject = schedulerObject.AddComponent<SchedulerDelayObject>();
            delayObject.Delay(() =>
            {
                onComplete?.Invoke();
                Object.Destroy(delayObject);
            }, time);
        }
    }
}