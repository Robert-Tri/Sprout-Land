using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    protected Animator animator;
    public float speed = 5f;
    public float pressHorizontal = 0;
    public float pressVertical = 0;
    Vector2 moveInput;
    private InputAction hoeAction;
    bool isAlive = true;
    private InputAction hoeAction;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        hoeAction = new InputAction(binding: "<Keyboard>/f", type: InputActionType.Button);
        hoeAction.performed += OnHoeActionPerformed;
        hoeAction.Enable();
    }

    private void OnHoeActionPerformed(InputAction.CallbackContext context)
    {
        animator.SetTrigger("TriggerHoeingRight");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.pressHorizontal = moveInput.x;
        this.pressVertical = moveInput.y;
        this.Move(); 
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    private void Move()
    {
        this.MoveDownAnimation();
        this.MoveUpAnimation();
        this.MoveLeftAnimation();
        this.MoveRightAnimation();
        Vector2 movementDirection = new Vector2(pressHorizontal, pressVertical).normalized;
        if (movementDirection.magnitude > 0)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        Vector3 movement = new Vector3(pressHorizontal, pressVertical, 0f) * speed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }

    

    private void MoveDownAnimation()
    {
        if (pressVertical < 0)
        {
            animator.SetBool("IsMovingDown", true);
        }
        else if (pressVertical > 0)
        {
            animator.SetBool("IsMovingDown", false);
        }
        else
        {
            animator.SetBool("IsMovingDown", false);
        }
    }
    private void MoveUpAnimation()
    {
        if (pressVertical > 0)
        {
            animator.SetBool("IsMovingUp", true);
        }
        else if (pressVertical < 0)
        {
            animator.SetBool("IsMovingUp", false);
        }
        else
        {
            animator.SetBool("IsMovingUp", false);
        }
    }
    private void MoveLeftAnimation()
    {
        if (pressHorizontal > 0)
        {
            animator.SetBool("IsMovingRight", true);
        }
        else if (pressHorizontal < 0)
        {
            animator.SetBool("IsMovingRight", false);
        }
        else
        {
            animator.SetBool("IsMovingRight", false);
        }
    }
    private void MoveRightAnimation()
    {
        if (pressHorizontal < 0)
        {
            animator.SetBool("IsMovingLeft", true);
        }
        else if (pressHorizontal > 0)
        {
            animator.SetBool("IsMovingLeft", false);
        }
        else
        {
            animator.SetBool("IsMovingLeft", false);
        }
    }
}
