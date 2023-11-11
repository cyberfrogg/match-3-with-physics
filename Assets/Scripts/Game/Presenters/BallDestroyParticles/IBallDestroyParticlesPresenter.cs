using Game.Views.BallDestroyParticles;
using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Presenters.BallDestroyParticles
{
    public interface IBallDestroyParticlesPresenter : IPresenter<IBallDestroyParticlesView>, IInjectable
    {
        Vector3 Position { get; set; }
    }
}