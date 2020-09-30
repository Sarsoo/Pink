using Pink.Environment;

namespace Pink.Timeline
{
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();

        public override void Execute()
        {
            //player.collider2d.enabled = true;
            state.player.controlAllowed = true;

            state.player.health.Reset();
            //state.player.Teleport(state.spawnPoint.transform.position);
            
            state.player.animator.SetBool("dead", false);
            state.virtualCamera.m_Follow = state.player.transform;
            state.virtualCamera.m_LookAt = state.player.transform;
            //Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}
