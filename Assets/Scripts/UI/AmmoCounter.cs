using TDS.Game.Common;
using TMPro;
using UnityEngine;

namespace TDS
{
    public class AmmoCounter : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _caption;
        [SerializeField] private AmmoHolder _ammoHolder;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _ammoHolder.OnChanged += UpdateCounter;
        }

        private void OnDestroy()
        {
            _ammoHolder.OnChanged -= UpdateCounter;
        }

        #endregion

        #region Private methods

        private void UpdateCounter(int value)
        {
            _caption.text = value.ToString();
        }

        #endregion
    }
}