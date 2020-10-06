using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    public Animator animator;
    public HeroInput input;

    private System.Random random;

    private void OnEnable() {
        input.Enable();
    }

    private void OnDisable() {
        input.Disable();
    }

    private void Awake() {
        input = new HeroInput();
        random = new System.Random();

        input.Player.Move.performed += ctx => OnMove(ctx);
        input.Player.Attack.performed += ctx => OnAttack(ctx);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Moving: " + context);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumping");
        animator.SetTrigger("Jump");
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        int attackNumber = random.Next(1,4);
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

    private void Update() {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();
        if(kb.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("SPACE");
        }
    }
 
}
