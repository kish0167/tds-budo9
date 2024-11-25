using TDS.Game.PickUps;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyLootHolder : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PickUp _pickUpPrefab;

        #endregion

        #region Properties

        public PickUp Loot => _pickUpPrefab;

        #endregion
    }
}