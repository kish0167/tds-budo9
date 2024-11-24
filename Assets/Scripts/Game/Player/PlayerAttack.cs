using Lean.Pool;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : PlayerAction
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private AmmoHolder _ammoHolder;

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        #endregion

        #region Private methods

        private void Fire()
        {
            if (_ammoHolder.IsEmpty())
            {
                return;
            }
            
            _ammoHolder.RemoveOne();
            _animation.TriggerAttack();
            LeanPool.Spawn(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}