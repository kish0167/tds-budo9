using System;
using TDS.Infrastructure.Locator;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Service.Restart
{
    public class RestartService : MonoBehaviour, IService
    {
        #region Variables

        private RestartCondition _currentCondition;

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
            RestartConditionHolder holder = FindObjectOfType<RestartConditionHolder>();
            _currentCondition = holder.Condition;
            _currentCondition.OnMet += ConditionMetCallback;
        }

        private void ConditionMetCallback()
        {
            // restart here
            this.Error();
            OnHappened?.Invoke();
        }

        #endregion
    }
}