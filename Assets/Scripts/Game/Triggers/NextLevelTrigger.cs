using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Game.Triggers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NextLevelTrigger : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _levelName;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            this.Error();
            if (!other.CompareTag(Tag.Player))
            {
                return;
            }
            
            ServicesLocator.Instance.Get<SceneLoaderService>().Load(_levelName);
        }

        #endregion
    }
}