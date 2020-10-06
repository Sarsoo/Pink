using Pink.Environment;
using Pink.Graphics;
using Pink.Events;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

using static Pink.Environment.Simulation;

namespace Pink.Mechanics
{
    [RequireComponent(typeof(CharacterKinematics))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Health))]
    public class PinkController : MonoBehaviour
    {
        public CharacterKinematics controller;
        public Collider2D collider2d;
        public Animator animator;
        public Health health;
        public Flash flash;

        public bool controlAllowed = true;

        [Min(0)]
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
            horizontalMovement = controlAllowed ? Input.GetAxisRaw("Horizontal") * runSpeed : 0;

            if (Input.GetButtonDown("Jump") && controlAllowed)
            {
                jump = true;
            }
        }

        private void FixedUpdate()
        {
            controller.Move(horizontalMovement * Time.fixedDeltaTime, jump);
            jump = false;
        }

        // Animation and graphic updates triggered primarily by health component
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
            if(flash != null) StartCoroutine(flash.Run(3, 60, 60, 1f));
        }

        // Animation and graphic updates triggered primarily by health component
        public void WasHealed()
        {
            animator.SetTrigger("");
        }

        // Animation, graphic updates and death event scheduling triggered primarily by health component
        public void WasKilled()
        {
            animator.SetBool("dead", true);
            Schedule<PlayerDeath>();
        }
    }
}