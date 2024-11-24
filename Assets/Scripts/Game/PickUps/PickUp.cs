using Lean.Pool;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Game.PickUps
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            ApplyEffects(other.gameObject);
        }

        #endregion

        #region Protected methods

        protected virtual void ApplyEffects(GameObject receiver)
        {
            LeanPool.Despawn(this);
        }

        #endregion
    }
}