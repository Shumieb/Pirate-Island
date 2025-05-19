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

    [SerializeField] bool followPlayer = false;

    [SerializeField] private float playerAwarenessDistance;

    [SerializeField] string shipColor;

    private Transform startPoint;

    private Vector2 playerDirection;
    private Vector2 startPointDirection;

    private float distanceFromPlayer;
    private float distanceToStartPoint;

    //private float baseSpeedModifier = 1f;    

    private Rigidbody2D rb;

    private Transform player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Start()
    {
        startPoint = EnemyRoamingStartPointsManager.Instance.GetStartPosition(shipColor);
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
                // rotate towards start point
                RotateTowardStartPoint();
                // move towards start point
                MoveTowardsStartPoint();
            }
        }             
    }

    private void UpdatePlayerFollow()
    {
        // get player direction
        playerDirection = UpdateTargetVector(player.position).normalized;

        // get player distance
        distanceFromPlayer = UpdateTargetVector(player.position).magnitude;

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
        RotateEnemy(playerDirection);
    }

    private void RotateTowardStartPoint()
    {
        // get start point direction
        startPointDirection = UpdateTargetVector(startPoint.position).normalized;

        // get start point distance
        distanceToStartPoint = UpdateTargetVector(startPoint.position).magnitude;

        RotateEnemy(startPointDirection);
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
            MoveEnemy();
        }
    }

    private void MoveTowardsStartPoint()
    {
        // check if the enemy is close to the start point
        if (distanceToStartPoint < minDistanceToStartPoint)
        {
            StopMovement();
        }
        else
        {
            // move towards start point
            MoveEnemy(speedModifier);
        }
    }

    private void RotateEnemy(Vector2 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, direction);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private Vector2 UpdateTargetVector(Vector3 targetPosition)
    {
        Vector2 enemyToTargetVector = targetPosition - transform.position;
        return enemyToTargetVector;
    }

    private void MoveEnemy( float modifier = 1f)
    {
        rb.velocity = transform.up * (moveSpeed * modifier * Time.deltaTime);
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
