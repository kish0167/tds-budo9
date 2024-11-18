using System;
using UnityEngine;

namespace TDS.Service.Restart
{
    public class RestartCondition : MonoBehaviour
    {
        public event Action OnMet;

        protected void OnConditionIsMet()
        {
            OnMet?.Invoke();
        }
    }
}