using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Cow : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    Vector2 targetPosition;

    private Animator animator;
    public float moveSpeed = 3f;

    void Start()
    {
        targetPosition = GetRandomPosition();

        animator = GetComponent<Animator>();
    }

    private Vector2 GetRandomPosition()
    {
        float randomX = Random.RandomRange(minX, maxX);
        float randomY = Random.RandomRange(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    void Update()
    {
        animator.SetBool("IsMoving", true);
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }
}