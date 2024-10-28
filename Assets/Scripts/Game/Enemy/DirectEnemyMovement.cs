using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class DirectEnemyMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (IsFinished())
            {
                return;
            }

            Rotate();
            Move();
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Private methods

        private bool IsFinished()
        {
            if (Target == null)
            {
                return true;
            }

            Vector2 dist = transform.position - Target.transform.position;
            bool isFinish = dist.magnitude <= 0.05f; //not o'k
            if (isFinish)
            {
                OnTargetReachedInvoke();
            }

            return isFinish;
        }

        private void Move()
        {
            Vector2 velocity = transform.up * _speed;
            _rb.velocity = velocity;
            // _animation.SetMovement(direction.magnitude);
        }

        private void Rotate()
        {
            transform.up = Target.position - transform.position;
        }

        #endregion
    }
}