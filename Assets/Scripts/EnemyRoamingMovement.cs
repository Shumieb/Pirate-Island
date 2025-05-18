using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float speedModifier = 0.4f;

    [SerializeField] private float rotationSpeed = 50f;

    [SerializeField] private float minDistanceToPlayer;
    [SerializeField] private float minDistanceToStartPoint;

    [SerializeField] float baseWaitTime = 5f;
    [SerializeField] bool startWaitTime = false;

    [SerializeField] bool followPlayer = false;
    [SerializeField] bool moveToStartPoint = false;

    [SerializeField] private float playerAwarenessDistance;

    private Transform startPoint;

    private Vector2 playerDirection;
    private Vector2 startPointDirection;

    private float distanceFromPlayer;
    private float distanceToStartPoint;

    [SerializeField] float waitTime = 5f;

    private Rigidbody2D rb;

    private Transform player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Start()
    {
        startPoint = EnemyRoamingStartPointsManager.Instance.GetGreyShipStartPosition();
        waitTime = baseWaitTime;
    }

    void Update()
    {
        UpdatePlayerFollow();
    }

    void FixedUpdate()
    {
        if (followPlayer)
        {
            // rotate towards player
            RotateTowardsPlayer();
            // move towards player
            MoveTowardsPlayer();
        }
        else {

            StopMovement();
            StopRotation();

            if (transform.position != startPoint.position)
            {
                // pause the enemy for a set time
                moveToStartPoint = true;

                RotateTowardStartPoint();
                MoveTowardsStartPoint();
            }
          
        }             
    }

    private void UpdatePlayerFollow()
    {
        // get player direction
        Vector2 enemyToPlayerVector = player.position - transform.position;
        playerDirection = enemyToPlayerVector.normalized;

        // get player distance
        distanceFromPlayer = enemyToPlayerVector.magnitude;

        // update followPlayer variable
        if (distanceFromPlayer < playerAwarenessDistance)
        {
            followPlayer = true;
        }
        else
        {
            followPlayer = false;
        }
    }

    private void RotateTowardsPlayer()
    { 
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, playerDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private void RotateTowardStartPoint()
    {
        // get player direction
        Vector2 enemyToStartPointVector = startPoint.position - transform.position;
        startPointDirection = enemyToStartPointVector.normalized;

        // get player distance
        distanceToStartPoint = enemyToStartPointVector.magnitude;

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, startPointDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private void MoveTowardsPlayer()
    {
        // check if the enemy is close to the player
        if (distanceFromPlayer < minDistanceToPlayer)
        {
            StopMovement();
        }
        else
        {
            // move towards player
            rb.velocity = transform.up * moveSpeed * Time.deltaTime;
        }
    }

    private void MoveTowardsStartPoint()
    {
        // check if the enemy is close to the start point
        if (distanceToStartPoint < minDistanceToStartPoint)
        {
            StopMovement();
            moveToStartPoint = false;
        }
        else
        {
            // move towards start point
            rb.velocity = transform.up * (moveSpeed * speedModifier * Time.deltaTime);
        }
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private void StopRotation()
    {
        playerDirection = Vector2.zero;
    }


}
