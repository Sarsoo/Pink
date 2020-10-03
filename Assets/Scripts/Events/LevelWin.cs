using Pink.Environment;
using Pink.Items;
using static Pink.Environment.Simulation;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pink.Events
{
    public class LevelWin : Simulation.Event<LevelWin>
    {
        EnvironmentModel state = Simulation.GetModel<EnvironmentModel>();

        public override void Execute()
        {
            SceneManager.LoadScene("second");
        }
    }
}
