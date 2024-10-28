using TDS.Game.Enemy.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS.Game.Enemy
{
    public class MeleeEnemyAttack : EnemyAttack
    {
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private Bullet _areaOfDamagePrefab;
        

        private float _timer;
        private void Update()
        {
            if (Target == null)
            {
                return;
            }

            Rotate();
            TryAttack();
        }
        private void Rotate()
        {
            transform.up = Target.position - transform.position;
        }
        
        private void TryAttack()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                return;
            }

            Attack();
            _timer = _attackDelay;
        }

        private void Attack()
        {
            // _animation.TriggerMeleeAttack();
            Instantiate(_areaOfDamagePrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }
    }
}