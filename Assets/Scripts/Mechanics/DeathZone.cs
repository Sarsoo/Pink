using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pink.Mechanics;
using Pink.Events;

namespace Pink.Mechanics {
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            var enteredHealth = other.gameObject.GetComponent<Health>();
            if (enteredHealth != null)
            {
                enteredHealth.Kill();
                
                var playerController = other.gameObject.GetComponent<PinkController>();
                if (playerController != null)
                {
                    playerController.controller.Bounce(1f);
                }
            }
        }
    }
}
