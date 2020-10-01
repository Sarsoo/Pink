using Pink.Environment;
using UnityEngine;

using static Pink.Environment.Simulation;

namespace Pink.Events
{
    class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();
        
        public override void Execute()
        {
            if (!state.player.health.IsAlive)
            {
                Debug.Log("Player Died");
                state.player.controlAllowed = false;
                state.player.collider2d.enabled = false;

                state.virtualCamera.m_Follow = null;
                state.virtualCamera.m_LookAt = null;

                Schedule<PlayerSpawn>(2);
            }
        }
    }
}
