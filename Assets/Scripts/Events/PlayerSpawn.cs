using Pink.Environment;
using Pink.Items;
using static Pink.Environment.Simulation;

using UnityEngine;

namespace Pink.Events
{
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();

        public override void Execute()
        {
            state.player.controlAllowed = true;
            state.player.collider2d.enabled = true;

            state.player.health.Reset();
            state.player.controller.Teleport(state.spawnPoint.transform.position);
            
            state.player.animator.SetBool("dead", false);
            state.virtualCamera.m_Follow = state.player.transform;
            state.virtualCamera.m_LookAt = state.player.transform;

            state.hud.Reset();
            state.items.ResetItems();

            // Schedule<EnableControl>(2f);
        }
    }
}
