using UnityEngine;
using Pink.UI;
using Pink.Items;

namespace Pink.Environment
{
    /// <summary>
    /// The main model containing needed data to implement a platformer style 
    /// game. This class should only contain data, and methods that operate 
    /// on the data. It is initialised with data in the GameController class.
    /// </summary>
    [System.Serializable]
    public class EnvironmentModel
    {
        /// <summary>
        /// The virtual camera in the scene.
        /// </summary>
        public Cinemachine.CinemachineVirtualCamera virtualCamera;

        /// <summary>
        /// The main component which controls the player sprite, controlled 
        /// by the user.
        /// </summary>
        public Pink.Mechanics.PinkController player;

        /// <summary>
        /// The spawn point in the scene.
        /// </summary>
        public Transform spawnPoint;

        /// <summary>
        /// The HUD controller for the scene.
        /// </summary>
        public HUDController hud;

        /// <summary>
        /// Item manager for collectibles in the scene.
        /// </summary>
        public ItemManager items;
    }
}
