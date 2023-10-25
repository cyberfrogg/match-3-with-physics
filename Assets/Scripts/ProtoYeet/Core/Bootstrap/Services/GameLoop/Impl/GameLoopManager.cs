using System;
using System.Collections.Generic;
using ProtoYeet.Core.Systems;
using Zenject;

namespace ProtoYeet.Core.Bootstrap.Services.GameLoop.Impl
{
    public class GameLoopManager : IGameLoopManager, ITickable
    {
        private readonly List<IUpdateSystem> _updateSystems = new ();
        
        public void AddUpdateListener(IUpdateSystem updateSystem)
        {
            if (_updateSystems.Contains(updateSystem))
                throw new ApplicationException($"This update system is already added.");
            
            _updateSystems.Add(updateSystem);
        }

        public void RemoveUpdateListener(IUpdateSystem updateSystem)
        {
            if (!_updateSystems.Contains(updateSystem))
                throw new ApplicationException($"This update system is not in pool.");

            _updateSystems.Remove(updateSystem);
        }

        public void Tick()
        {
            foreach (var updateSystem in _updateSystems)
            {
                updateSystem.Update();
            }
        }
    }
}