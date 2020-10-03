using UnityEngine;
using UnityEngine.Events;
using Pink.Mechanics;
using Pink.Events;

using static Pink.Environment.Simulation;

namespace Pink.Items
{
    [RequireComponent(typeof(Collider2D))]
    public class ItemController : MonoBehaviour
    {
        public Animator animator;
        public UnityEvent OnCollect;

        public bool isCollected { get; private set; } = false;

        public ItemManager manager;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var userController = collider.gameObject.GetComponent<PinkController>();

            if (userController != null)
            {
                Collect();
            }
        }

        public void Collect()
        {
            Debug.Log("Item Collected");
            isCollected = true;
            if (animator != null) animator.SetTrigger("collected");
            GetComponent<Collider2D>().enabled = false;
            manager.ItemCollected(this);
            OnCollect.Invoke();
            Schedule<ItemCollection>();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Reset()
        {
            gameObject.SetActive(true);
            isCollected = false;
            if (animator != null) animator.SetTrigger("reset");
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
