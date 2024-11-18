using System;
using TDS.Infrastructure.Locator;
using TDS.Service.GameOver;
using TDS.Service.Respawn;
using TDS.Utils.Log;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _respawnButton;
        [SerializeField] private GameObject _content;

        #endregion

        public event Action OnRespawn;
        
        private void Start()
        {
            _respawnButton.onClick.AddListener(RespawnButtonClickedCallback);
            
            _content.SetActive(false);
            ServicesLocator.Instance.Get<GameOverService>().OnHappened += GameOverCallback;
            ServicesLocator.Instance.Get<RespawnService>().OnHappened += RespawnCallback;
        }

        private void OnDestroy()
        {
            _respawnButton.onClick.RemoveListener(RespawnButtonClickedCallback);
            ServicesLocator.Instance.Get<GameOverService>().OnHappened -= GameOverCallback;
            ServicesLocator.Instance.Get<RespawnService>().OnHappened -= RespawnCallback;
        }

        private void GameOverCallback()
        {
            _content.SetActive(true);
        }

        private void RespawnButtonClickedCallback()
        {
            OnRespawn?.Invoke();
        }

        private void RespawnCallback()
        {
            _content.SetActive(false);
        }
    }
}