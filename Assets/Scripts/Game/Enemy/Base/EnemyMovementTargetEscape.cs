using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyMovementTargetEscape : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private Transform _homeWayPoint;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserver.OnExited += TriggerExitedCallback;
            _movement.OnTargetReached += TargetReachedCallback;
        }

        private void OnDisable()
        {
            _triggerObserver.OnExited -= TriggerExitedCallback;
            _movement.OnTargetReached -= TargetReachedCallback;
        }

        #endregion

        #region Private methods

        private void TargetReachedCallback()
        {
            _movement.Deactivate();
            _idle.Activate();
        }

        private void TriggerExitedCallback(Collider2D col)
        {
            if (!col.CompareTag(Tag.Player))
            {
                return;
            }

            _idle.Deactivate();
            _movement.Activate();
            _movement.SetTarget(_homeWayPoint);
        }

        #endregion
    }
}