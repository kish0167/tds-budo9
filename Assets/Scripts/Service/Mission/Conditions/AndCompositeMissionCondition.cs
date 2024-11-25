using System.Collections.Generic;
using UnityEngine;

namespace TDS.Service.Mission.Conditions
{
    public class AndCompositeMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private MissionCondition[] _conditions;

        #endregion

        #region Properties

        public IReadOnlyList<MissionCondition> Conditions => _conditions;

        #endregion
    }
}