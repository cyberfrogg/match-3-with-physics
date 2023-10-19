using System.Collections.Generic;
using ProtoYeet.Core.Log.Services;
using ProtoYeet.Core.Systems;
using Zenject;

namespace ProtoYeet.Core.Bootstrap
{
    public class Bootstrap : 
        IInitializable, 
        ITickable
    {
        private readonly List<IUiInitialize> _uiInitializes;
        private readonly ILoggerService _loggerService;
        private readonly List<IInitializeSystem> _initializeSystems = new();
        private readonly List<IUpdateSystem> _update = new();
        
        private bool _isInitialized;
        
        public Bootstrap(
            List<ISystem> systems,
            List<IUiInitialize> uiInitializes,
            ILoggerService loggerService
            )
        {
            _loggerService = loggerService;
            
            _uiInitializes = uiInitializes;
            
            foreach (var system in systems)
            {
                if(system is IInitializeSystem initializeSystem)
                    _initializeSystems.Add(initializeSystem);
                
                if(system is IUpdateSystem updateSystem)
                    _update.Add(updateSystem);
            }
        }
        
        public void Initialize()
        {
            if(_isInitialized)
                return;
            
            _isInitialized = true;

            // init systems
            foreach (var initializeSystem in _initializeSystems)
            {
                initializeSystem.Initialize();
            }
            
            // init ui
            foreach (var uiInitialize in _uiInitializes)
            {
                uiInitialize.Initialize();
            }
        }

        public void Tick()
        {
            foreach (var updateSystem in _update)
            {
                updateSystem.Update();
            }
        }
    }
}