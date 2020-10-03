using Pink.Environment;
using Pink.Items;
using static Pink.Environment.Simulation;

using UnityEngine;

namespace Pink.Events
{
    public class ItemCollection : Simulation.Event<ItemCollection>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();

        public override void Execute()
        {
            state.player.health.Heal(1f);
        }
    }
}
