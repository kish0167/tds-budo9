using System;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        #region Events

        public event Action OnTargetReached;

        #endregion

        #region Properties

        protected Transform Target { get; private set; }

        #endregion

        #region Public methods

        public void SetTarget(Transform target)
        {
            Target = target;
        }

        #endregion

        #region Protected methods

        protected void OnTargetReachedInvoke()
        {
            OnTargetReached?.Invoke();
        }

        #endregion
    }
}