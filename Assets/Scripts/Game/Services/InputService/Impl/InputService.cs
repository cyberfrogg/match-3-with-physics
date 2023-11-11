using System;
using Game.Providers.GameFieldProvider;

namespace Game.Services.InputService.Impl
{
    public class InputService : IInputService
    {
        private readonly IGameFieldProvider _gameFieldProvider;
        public event Action OnTap;

        public InputService(
            IGameFieldProvider gameFieldProvider
            )
        {
            _gameFieldProvider = gameFieldProvider;
            _gameFieldProvider.GameFieldView.InputView.OnTap += OnTapExecutedOnView;
        }

        private void OnTapExecutedOnView()
        {
            OnTap?.Invoke();
        }
    }
}