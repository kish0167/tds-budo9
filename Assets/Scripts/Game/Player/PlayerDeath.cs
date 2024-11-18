using System;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : PlayerAction
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private PlayerAnimation _animation;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _hp.OnChanged += HpChangedCallback;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= HpChangedCallback;
        }

        #endregion

        #region Private methods

        private void Die()
        {
            IsDead = true;

            _collider.enabled = false;
            _movement.Deactivate();
            _attack.Deactivate();
            // TODO: _animation.PlayDeath(); 
            OnHappened?.Invoke();
        }

        private void HpChangedCallback(int hp)
        {
            if (hp > 0 || IsDead)
            {
                return;
            }

            Die();
        }

        #endregion
    }
}