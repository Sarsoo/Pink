using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pink.Mechanics
{
    public class PinkController : MonoBehaviour
    {
        public CharacterKinematics controller;
        public Animator animator;
        public Health health;

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
            horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
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
        }

        public void WasHealed()
        {
            animator.SetTrigger("");
        }
    }
}