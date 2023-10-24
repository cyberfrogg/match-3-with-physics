using ProtoYeet.Core.Loading.Services.LevelLoading;

namespace Menu.Services.Impl
{
    public class MenuLoadLevelsService : IMenuLoadLevelsService
    {
        private readonly ILevelLoadingService _levelLoadingService;

        public MenuLoadLevelsService(
            ILevelLoadingService levelLoadingService
            )
        {
            _levelLoadingService = levelLoadingService;
        }

        public void LoadSandbox()
        {
            _levelLoadingService.Load("SandBox");
        }
    }
}