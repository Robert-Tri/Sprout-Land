using Assets._Scripts.Models;
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
    [SerializeField] private BoxCollider2D fenceCollider;
    [SerializeField] private GameObject player;


    private Animator animator;
    public float moveSpeed = 3f;

    void Start()
    {
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

        if (fenceCollider.bounds.Contains(player.transform.position))
            MoveToPlayer();
        else
            MoveRandomly();
    }
    void MoveRandomly()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }
    void MoveToPlayer()
    {
         Vector3 direction = (player.transform.position - transform.position).normalized;
         transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}