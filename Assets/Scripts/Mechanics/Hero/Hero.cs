using Pink.Environment;
using Pink.Graphics;
using Pink.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

using static Pink.Environment.Simulation;

namespace Pink.Mechanics
{
    [RequireComponent(typeof(CharacterKinematics))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Health))]
    public class Hero : MonoBehaviour
    {
        public HeroInput input;
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

        private System.Random random;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Player Created");
        }
        void Awake()
        {
            input = new HeroInput();
            random = new System.Random();

            input.Player.Move.performed += ctx => OnMove(ctx);
            input.Player.Jump.performed += ctx => OnJump(ctx);
            input.Player.Attack.performed += ctx => OnAttack(ctx);
            input.Player.Block.performed += ctx => OnBlock(ctx);
            input.Player.Roll.performed += ctx => OnRoll(ctx);
        }
        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            horizontalMovement = controlAllowed ? context.ReadValue<Vector2>().x * runSpeed : 0;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (controlAllowed)
            {
                Debug.Log("Jumping");
                animator.SetTrigger("Jump");
                jump = true;
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            int attackNumber = random.Next(1, 4);
            animator.SetTrigger("Attack" + attackNumber.ToString());
        }

        public void OnBlock(InputAction.CallbackContext context)
        {
            animator.SetTrigger("Block");
        }

        public void OnRoll(InputAction.CallbackContext context)
        {
            Debug.Log("Rolling");
            animator.SetTrigger("Roll");
        }

        // Update is called once per frame
        void Update()
        {
            
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
            if (flash != null) StartCoroutine(flash.Run(3, 60, 60, 1f));
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