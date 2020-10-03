using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Pink.Mechanics;

namespace Pink.UI {
    public class HUDController : MonoBehaviour
    {
        public TextMeshProUGUI healthDisplay;
        public PinkController playerController;

        public void UpdateHealth()
        {
            healthDisplay.SetText(playerController.health.CurrentHealth.ToString());
        }

        public void Reset()
        {
            healthDisplay.SetText(playerController.health.CurrentHealth.ToString());
        }
    }
}