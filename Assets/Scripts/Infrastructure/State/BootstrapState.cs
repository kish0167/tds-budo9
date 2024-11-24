using TDS.Service.Coroutine;
using TDS.Service.GameOver;
using TDS.Service.LevelCompletion;
using TDS.Service.LevelLoading;
using TDS.Service.Mission;
using TDS.Service.Respawn;
using TDS.Service.SceneLoading;
using TDS.Utils.Log;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            this.Log();

            ServicesLocator.Register(new SceneLoaderService());
            LevelLoadingService levelLoadingService = new(ServicesLocator.Get<StateMachine>());
            ServicesLocator.Register(levelLoadingService);
            MissionService missionService = ServicesLocator.RegisterMono<MissionService>();
            ServicesLocator.Register(new LevelCompletionService(missionService, levelLoadingService));
            ServicesLocator.RegisterMono<CoroutineRunner>();
            ServicesLocator.RegisterMono<GameOverService>();
            ServicesLocator.RegisterMono<RespawnService>();

            levelLoadingService.Initialize();
            levelLoadingService.EnterFirstLevel();
        }

        public override void Exit() { }

        #endregion
    }
}