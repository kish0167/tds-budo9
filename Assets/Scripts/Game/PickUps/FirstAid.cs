using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.PickUps
{
    public class FirstAid : PickUp
    {
        [SerializeField] private uint _healingAmount;

        protected override void ApplyEffects(GameObject receiver)
        {
            if (!receiver.TryGetComponent(out UnitHp unitHp))
            {
                return;
            }

            unitHp.Change((int)_healingAmount);
            base.ApplyEffects(receiver);
        }
    }
}