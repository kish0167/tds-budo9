using TDS.Game.Player;
using UnityEngine;

namespace TDS.Service.GameOver.Conditions
{
    public class PlayerDeadCondition : GameOverCondition
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