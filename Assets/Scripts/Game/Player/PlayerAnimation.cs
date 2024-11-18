using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAnimation : PlayerAction
    {
        #region Variables

        private static readonly int Fire = Animator.StringToHash("fire");
        private static readonly int Movement = Animator.StringToHash("movement");
        private static readonly int Death = Animator.StringToHash("death");
        private static readonly int Respawn = Animator.StringToHash("respawn");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void SetMovement(float speed)
        {
            _animator.SetFloat(Movement, speed);
        }

        public void TriggerAttack()
        {
            _animator.SetTrigger(Fire);
        }

        #endregion

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void PlayRespawn()
        {
            _animator.SetTrigger(Respawn);
        }
    }
}