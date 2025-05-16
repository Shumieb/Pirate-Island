using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{

    public bool AwareOfPlayer {  get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    public float DistanceFromPlayer { get; private set; }

    [SerializeField] private float playerAwarenessDistance;
  
    private Transform player;

    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        DistanceFromPlayer = enemyToPlayerVector.magnitude;

        if(DistanceFromPlayer <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer= false;
        }
    }
}
