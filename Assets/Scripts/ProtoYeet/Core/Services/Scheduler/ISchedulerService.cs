using System;

namespace ProtoYeet.Core.Services.Scheduler
{
    public interface ISchedulerService
    {
        void Delay(Action onComplete, float time);
    }
}