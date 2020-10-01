using Pink.Environment;
using UnityEngine;

namespace Pink.Events
{
    class PlayerHurt : Simulation.Event<PlayerHurt>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();
        
        public override void Execute()
        {
            if (state.player.health.IsAlive)
            {
                Debug.Log("Player Hurt");
            }
        }
    }
}
