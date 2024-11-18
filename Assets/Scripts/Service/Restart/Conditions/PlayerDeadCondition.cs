using System;
using TDS.Game;
using TDS.Game.Common;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Service.Restart.Conditions
{
    public class PlayerDeadCondition : RestartCondition
    {
        [SerializeField] private PlayerDeath _death;

        private void Start()
        {
            _death.OnHappened += OnConditionIsMet;
        }

        private void OnDestroy()
        {
            _death.OnHappened -= OnConditionIsMet;
        }
    }
}