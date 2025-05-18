using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingMovement : MonoBehaviour
{

    [SerializeField] bool playerInRange = false;
    [SerializeField] bool playerFound=false;

    [SerializeField] bool canFollowplayer = false;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float minDistanceToPlayer;

    private Vector2 directionToPlayer;
    private float distanceToPlayer;
    private Transform player;

    private Rigidbody2D rb;

    void Awake()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // get a reference to the player when the player is in range
        if(playerInRange && !playerFound)
        {
            // find the reference to the player
            player = FindObjectOfType<PlayerMovement>().transform;
            
            if(player != null)
            {
                // set the player found to false
                playerFound = true;
            }
        }

        if(playerInRange && playerFound)
        {
           // get player direction and distance
            Vector2 enemyToPlayerVector = player.position - transform.position;
            directionToPlayer = enemyToPlayerVector.normalized;
            distanceToPlayer = enemyToPlayerVector.magnitude;

            // rotate towards player
            RotateTowardsTarget();

            // move towards player
            MoveTowardsPlayer();
        }

        if(!playerInRange && playerFound)
        {
            playerFound= false;
            player = null;
        }
    }

    private void RotateTowardsTarget()
    {
        if (directionToPlayer == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, directionToPlayer);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private void MoveTowardsPlayer()
    {
        if (directionToPlayer == Vector2.zero || distanceToPlayer <= minDistanceToPlayer)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * moveSpeed * Time.deltaTime;
        }
    }

    public void SetPlayerInRange(bool value)
    {
        playerInRange = value;
    }

}
