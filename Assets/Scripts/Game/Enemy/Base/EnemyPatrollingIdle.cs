using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyPatrollingIdle : EnemyIdle
    {
        #region Variables

        [SerializeField] private List<Transform> _route;
        [SerializeField] private EnemyMovement _movement;

        private Transform _currentWayPoint;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            if (_route.Count > 0)
            {
                _currentWayPoint = _route[0];
            }

            _movement.Activate();
            _movement.SetTarget(_currentWayPoint);
        }

        private void OnEnable()
        {
            _movement.OnTargetReached += TargetReachedCallback;
            _movement.Activate();
            _movement.SetTarget(_currentWayPoint);
        }

        private void OnDisable()
        {
            _movement.OnTargetReached -= TargetReachedCallback;
        }

        #endregion

        #region Private methods

        private Transform GetNextWaypoint()
        {
            int index = _route.IndexOf(_currentWayPoint) + 1;
            if (index >= _route.Count)
            {
                index = 0;
            }

            _currentWayPoint = _route[index];
            return _route[index];
        }

        private void TargetReachedCallback()
        {
            _movement.SetTarget(GetNextWaypoint());
            _movement.Activate();
        }

        #endregion
    }
}