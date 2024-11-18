using System;
using TDS.Infrastructure.Locator;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Service.GameOver
{
    public class GameOverService : MonoBehaviour, IService
    {
        #region Variables

        private GameOverCondition _currentCondition;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Public methods

        public void Dispose()
        {
            _currentCondition.OnMet -= ConditionMetCallback;
        }

        public void Initialize()
        {
            GameOverConditionHolder holder = FindObjectOfType<GameOverConditionHolder>();
            _currentCondition = holder.Condition;
            _currentCondition.OnMet += ConditionMetCallback;
        }

        #endregion

        #region Private methods

        private void ConditionMetCallback()
        {
            // restart here
            this.Error();
            OnHappened?.Invoke();
        }

        #endregion
    }
}