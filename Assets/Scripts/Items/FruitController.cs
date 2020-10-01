using UnityEngine;
using UnityEngine.SceneManagement;
using Pink.Mechanics;

namespace Pink.Items
{
    class FruitController : MonoBehaviour
    {
        public Animator animator;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var userController = collider.gameObject.GetComponent<PinkController>();

            if (userController != null)
            {
                animator.SetTrigger("collected");
                Collect();
                SceneManager.LoadScene("second");
            }
        }

        public void Collect()
        {
            animator.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
