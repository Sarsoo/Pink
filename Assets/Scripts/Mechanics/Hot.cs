using UnityEngine;

namespace Pink.Mechanics
{
    public class Hot : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.gameObject.GetComponent<PinkController>();
            if (player != null)
            {
                Debug.Log("Player Burnt");
                player.health.Hurt(2f);
                collider.gameObject.GetComponent<Rigidbody2D>().velocity *= -0.8f;
            }
        }
    }
}