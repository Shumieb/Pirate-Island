using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip")
        {
            // Deduct health from the Enemy

            // Destroy the Bullet
            Destroy(gameObject);
        }

    }
}
