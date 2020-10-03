using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pink.Mechanics;

public class JumpPadController : MonoBehaviour
{
    public Transform padCheck;
    public Animator animator;
    [Min(0)] public float bounceForce = 15f; 

    private void OnCollisionEnter2D(Collision2D other) {
        var playerController = other.gameObject.GetComponent<PinkController>();

        if (playerController != null)
        {
            if (playerController.controller.m_GroundCheck.position.y > padCheck.position.y)
            {
                Debug.Log("Bounced");
                animator.SetTrigger("bounce");
                other.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, bounceForce);
            }
            else{
                Debug.Log("Player not above pad");
            }
        }
    }
}