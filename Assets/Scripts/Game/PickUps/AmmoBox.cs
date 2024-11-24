using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.PickUps
{
    public class AmmoBox : PickUp
    {
        #region Variables

        [SerializeField] private uint _ammoAmount;

        #endregion

        #region Protected methods

        protected override void ApplyEffects(GameObject receiver)
        {
            if (!receiver.TryGetComponent(out AmmoHolder ammoHolder))
            {
                return;
            }

            ammoHolder.AddAmmo(_ammoAmount);
            base.ApplyEffects(receiver);
        }

        #endregion
    }
}