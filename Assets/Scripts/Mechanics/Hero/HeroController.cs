using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pink.Mechanics
{
    public class HeroController : Pink.Mechanics.Kinematic
    {
        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public Animator animator;
        public HeroInput input;
        private System.Random random;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/
        public Collider2D collider2d;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => collider2d.bounds;

        // Start is called before the first frame update
        void Awake()
        {
            health = GetComponent<Health>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

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
            if (controlEnabled)
            {
                move.x = context.ReadValue<Vector2>().x;
                animator.SetFloat("", move.x);
                Debug.Log("Moving: " + move.x);
            }
            else
            {
                move.x = 0;
            }
            
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (jumpState == JumpState.Grounded)
                jumpState = JumpState.PrepareToJump;
            
            // stopJump = true; on up

            Debug.Log("Jumping");
            animator.SetTrigger("Jump");
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
        protected override void Update()
        {
            //if (controlEnabled)
            //{
            //    move.x = Input.GetAxis("Horizontal");
            //    if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
            //        jumpState = JumpState.PrepareToJump;
            //    else if (Input.GetButtonUp("Jump"))
            //    {
            //        stopJump = true;
            //    }
            //}
            //else
            //{
            //    move.x = 0;
            //}
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    //velocity.y = velocity.y;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
            animator.SetFloat("velocityY", velocity.y);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}