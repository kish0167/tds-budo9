using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAction : MonoBehaviour
    {
        public void Deactivate()
        {
            enabled = false;
        }
        
        public void Activate()
        {
            enabled = true;
        }
    }
}