using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemyMove : MonoBehaviour
{

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveEnemy(float moveSpeed, float modifier)
    {
        rb.velocity = transform.up * (moveSpeed * modifier * Time.deltaTime);
    }

    public void StopEnemy()
    {
        rb.velocity = Vector2.zero;
    }
}
