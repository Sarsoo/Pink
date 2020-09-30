using UnityEngine;

namespace Pink.Items
{
    class Firepit: MonoBehaviour
    {
        public ParticleSystem explosionParticles;

        void OnTriggerEnter2D(Collider2D collider)
        {
            explosionParticles.Play();
        }
    }
}
