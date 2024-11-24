using Pathfinding;
using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy 
{
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(AIDestinationSetter))]
    public class AstarEnemyMovement : EnemyMovement 
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private AIPath _aiPath;
        [SerializeField] private AIDestinationSetter _destinationSetter;

        private Transform _target;

        #endregion
        #region Unity lifecycle

        private void OnDisable()
        {
            StopMoving();
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _destinationSetter.target = target;

            if (target != null)
            {
                StartMoving();
            }
        }

        #endregion

        #region Private methods

        private void StartMoving()
        {
            _aiPath.enabled = true;
            _aiPath.maxSpeed = _speed;
            Animation.SetSpeed(_speed);
        }

        private void StopMoving()
        {
            _aiPath.enabled = false;
            Animation.SetSpeed(0);
        }

        #endregion
    }
}