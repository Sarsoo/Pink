using Pink.Environment;
using Pink.Graphics;
using Pink.Events;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

using static Pink.Environment.Simulation;

namespace Pink.Mechanics
{
    public class PinkController : MonoBehaviour
    {
        public CharacterKinematics controller;
        public Collider2D collider2d;
        public Animator animator;
        public Health health;
        public Flash flash;

        public bool controlAllowed = true;

        public float runSpeed = 40f;
        float horizontalMovement = 0f;
        bool jump = false;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Player Created");
        }

        // Update is called once per frame
        void Update()
        {
            if (controlAllowed)
            {
                horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }
            }
        }

        private void FixedUpdate()
        {
            controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
            jump = false;
        }

        public void WasHurt()
        {
            if (health.IsDead)
            {
                animator.SetTrigger("dead");
            }
            else
            {
                animator.SetTrigger("hurt");
            }
            StartCoroutine(Simulation.GetModel<EnvironmentModel>().virtualCamera.GetComponent<Shake>().Run(400f, 6f, 9f));
            StartCoroutine(flash.Run(3, 60, 60, 1f));
        }

        public void WasHealed()
        {
            animator.SetTrigger("");
        }

        public void WasKilled()
        {
            animator.SetBool("dead", true);
            Schedule<PlayerDeath>();
        }
    }
}