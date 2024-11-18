using System;
using TDS.Infrastructure.Locator;
using TDS.UI;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Service.Respawn
{
    public class RespawnService : MonoBehaviour, IService
    {
        #region Variables

        private GameOverScreen _screen;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Public methods

        public void Dispose()
        {
            _screen.OnRespawn -= RespawnCallback;
        }

        public void Initialize()
        {
            _screen = FindObjectOfType<GameOverScreen>();
            _screen.OnRespawn += RespawnCallback;
        }

        #endregion

        #region Private methods

        private void RespawnCallback()
        {
            // restart here
            this.Error();
            OnHappened?.Invoke();
        }

        #endregion
    }
}