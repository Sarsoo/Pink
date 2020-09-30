using Pink.Environment;

namespace Pink.Timeline
{
    class PlayerDeath : Simulation.Event
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();
        
        public override void Execute()
        {
            if (state.player.health.IsAlive)
            {
                state.player.health.Die();
                state.player.controlAllowed = false;

                state.virtualCamera.m_Follow = null;
                state.virtualCamera.m_LookAt = null;

                state.player.animator.SetTrigger("hurt");
                state.player.animator.SetBool("dead", true);
                //Simulation.Schedule<PlayerSpawn>(2);
            }
        }
    }
}
