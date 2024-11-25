using System;
using UnityEngine;

namespace TDS.Game.Common
{
    public class AmmoHolder : MonoBehaviour
    {
        #region Variables

        [SerializeField] private uint _startAmmo;

        private int _ammo;

        #endregion

        #region Events

        public event Action<int> OnChanged;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            ResetAmmo();
        }

        #endregion

        #region Public methods

        public void AddAmmo(uint ammoAmount)
        {
            _ammo += (int)ammoAmount;
            OnChanged?.Invoke(_ammo);
        }

        public bool IsEmpty()
        {
            return _ammo <= 0;
        }

        public void RemoveOne()
        {
            _ammo--;
            OnChanged?.Invoke(_ammo);
        }

        public void ResetAmmo()
        {
            _ammo = (int)_startAmmo;
            OnChanged?.Invoke(_ammo);
        }

        #endregion
    }
}