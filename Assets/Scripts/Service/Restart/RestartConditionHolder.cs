using UnityEngine;

namespace TDS.Service.Restart
{
    public class RestartConditionHolder : MonoBehaviour 
    {
        #region Variables

        [SerializeReference] private RestartCondition _condition;

        #endregion

        #region Properties

        public RestartCondition Condition => _condition;

        #endregion
    }
}