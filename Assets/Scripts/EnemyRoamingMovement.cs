using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float minDistanceToPlayer;

    [SerializeField] float baseWaitTime = 5f;
    [SerializeField] bool startWaitTime = false;

    [SerializeField] Transform startPoint;
    [SerializeField] bool moveToStartPoint;

    private Vector2 playerDirection;

    private float waitTime;

    private PlayerAwarenessController playerAwarenessController;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        waitTime = baseWaitTime;
    }

    void FixedUpdate()
    {       
        //update Target distance
        UpdatePlayerDirection();

        // rotate towards player
        RotateTowardsPlayer();

        // move towards player
        MoveTowardsPlayer();

        if (startWaitTime && waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }

        if(waitTime <= 0)
        {
            startWaitTime = false;
            moveToStartPoint = true;
            waitTime = baseWaitTime;
        }

        if(moveToStartPoint)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
        }
    }

    private void UpdatePlayerDirection()
    {
        if (playerAwarenessController.AwareOfPlayer)
        {
            playerDirection = playerAwarenessController.DirectionToPlayer;

            // stop enemy moving towards start point
            moveToStartPoint = false;
            startWaitTime = false;
            waitTime = baseWaitTime;
        }
        else
        {
            playerDirection = Vector2.zero;
        }
    }

    private void RotateTowardsPlayer()
    {
        if (playerDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, playerDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private void MoveTowardsPlayer()
    {
        if (playerDirection == Vector2.zero || playerAwarenessController.DistanceFromPlayer < minDistanceToPlayer)
        {
            rb.velocity = Vector2.zero;

            // get player to move towards start point
            startWaitTime = true;
        }
        else
        {
            rb.velocity = transform.up * moveSpeed * Time.deltaTime;
        }
    }

}
