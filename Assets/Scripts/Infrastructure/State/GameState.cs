using TDS.Game.Common;
using TDS.Game.Player;
using TDS.Service.GameOver;
using TDS.Service.LevelCompletion;
using TDS.Service.Mission;
using TDS.Service.Respawn;
using TDS.UI;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            this.Log();
            ServicesLocator.Get<LevelCompletionService>().Initialize();
            ServicesLocator.Get<MissionService>().Initialize();
            ServicesLocator.Get<MissionService>().Begin();
            ServicesLocator.Get<GameOverService>().Initialize();
            ServicesLocator.Get<RespawnService>().Initialize();

            GameScreen gameScreen = Object.FindObjectOfType<GameScreen>();
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            UnitHp playerHp = playerMovement.GetComponent<UnitHp>();
            gameScreen.PlayerHpBar.Construct(playerHp);
        }

        public override void Exit()
        {
            ServicesLocator.Get<LevelCompletionService>().Dispose();
            ServicesLocator.Get<MissionService>().Dispose();
            ServicesLocator.Get<GameOverService>().Dispose();
            ServicesLocator.Get<RespawnService>().Dispose();
        }

        #endregion
    }
}