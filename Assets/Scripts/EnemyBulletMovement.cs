using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    private Transform player;

    [SerializeField] float moveSpeed = 5.0f;

    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
         transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
   
}
