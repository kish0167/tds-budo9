using System;
using UnityEngine;

namespace TDS.Game.Common
{
    public class AmmoHolder : MonoBehaviour
    {
        [SerializeField] private uint _startAmmo;
        
        private int _ammo;

        private void Start()
        {
            _ammo = (int)_startAmmo;
        }

        public bool IsEmpty()
        {
            return _ammo <= 0;
        }

        public void RemoveOne()
        {
            _ammo--;
        }

        public void AddAmmo(uint ammoAmount)
        {
            _ammo += (int)ammoAmount;
        }
    }
}
