using UnityEngine;

namespace Pink.Mechanics
{
    public class Hot : MonoBehaviour
    {
        public float Damage = 2f; 
            
        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.gameObject.GetComponent<PinkController>();
            if (player != null)
            {
                Debug.Log("Player Burnt");
                player.health.Hurt(Damage);
                player.controller.Bounce(0.8f);
            }
        }
    }
}
