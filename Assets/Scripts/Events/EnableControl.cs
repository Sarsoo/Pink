using Pink.Environment;

namespace Pink.Events
{
    public class EnableControl : Simulation.Event<EnableControl>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();

        public override void Execute()
        {
            state.player.controlAllowed = true;
        }
    }
}
