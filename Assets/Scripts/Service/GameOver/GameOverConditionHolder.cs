using UnityEngine;

namespace TDS.Service.GameOver
{
    public class GameOverConditionHolder : MonoBehaviour 
    {
        #region Variables

        [SerializeReference] private GameOverCondition _condition;

        #endregion

        #region Properties

        public GameOverCondition Condition => _condition;

        #endregion
    }
}