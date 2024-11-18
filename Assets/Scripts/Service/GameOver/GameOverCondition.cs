using System;
using UnityEngine;

namespace TDS.Service.GameOver
{
    public class GameOverCondition : MonoBehaviour
    {
        public event Action OnMet;

        protected void OnConditionIsMet()
        {
            OnMet?.Invoke();
        }
    }
}