using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 3f; 
    private Vector2 randomDirection;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        randomDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        animator.SetBool("IsMoving", randomDirection.magnitude > 0.1f);
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        randomDirection = -randomDirection;
    }
}
