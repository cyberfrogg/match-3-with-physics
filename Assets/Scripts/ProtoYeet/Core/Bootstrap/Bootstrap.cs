using System.Collections.Generic;
using ProtoYeet.Core.Systems;
using Zenject;

namespace ProtoYeet.Core.Bootstrap
{
    public class Bootstrap : 
        IInitializable
    {
        private readonly List<IUiInitialize> _uiInitializes;
        private readonly List<IInitializeSystem> _initializeSystems = new();
        
        private bool _isInitialized;
        
        public Bootstrap(
            List<ISystem> systems,
            List<IUiInitialize> uiInitializes
            )
        {
            
            _uiInitializes = uiInitializes;
            
            foreach (var system in systems)
            {
                if(system is IInitializeSystem initializeSystem)
                    _initializeSystems.Add(initializeSystem);
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
    }
}