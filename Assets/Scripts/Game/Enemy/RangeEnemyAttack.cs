using Lean.Pool;
using TDS.Game.Common;
using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class RangeEnemyAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(RangeEnemyAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private AmmoHolder _ammoHolder;

        #endregion

        #region Unity lifecycle

        protected override void Update()
        {
            base.Update();

            if (Target == null)
            {
                return;
            }

            Rotate();
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            if (_ammoHolder.IsEmpty())
            {
                // Out of ammo
                return;
            }
            
            base.OnPerformAttack();
            _ammoHolder.RemoveOne();
            LeanPool.Spawn(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion

        #region Private methods

        private void Rotate()
        {
            transform.up = Target.position - transform.position;
        }

        #endregion
    }
}