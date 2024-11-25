using TDS.Game.Common;
using TDS.Infrastructure.Locator;
using TDS.Service.Respawn;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerRespawn : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private PlayerDeath _death;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private AmmoHolder _ammoHolder;

        private Vector3 _startPos;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startPos = transform.position;
        }

        private void OnEnable()
        {
            ServicesLocator.Instance.Get<RespawnService>().OnHappened += RespawnCallback;
        }

        private void OnDisable()
        {
            ServicesLocator.Instance.Get<RespawnService>().OnHappened -= RespawnCallback;
        }

        #endregion

        #region Private methods

        private void Respawn()
        {
            _hp.Reset();
            _collider.enabled = true;
            _movement.Activate();
            _attack.Activate();
            _animation.PlayRespawn();
            _death.Reset();
            transform.position = _startPos;
            _ammoHolder.ResetAmmo();
        }

        private void RespawnCallback()
        {
            Respawn();
        }

        #endregion
    }
}