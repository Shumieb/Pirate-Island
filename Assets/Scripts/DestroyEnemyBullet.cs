using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{

    [SerializeField] float damageAmount = 2.0f;

    private void Awake()
    {
        damageAmount = EnemyDamageAmountManager.Instance.GetDamageAmount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShield")
        {
            // Destroy the Bullet
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerShip")
        {
            // Deduct health from the player
            collision.gameObject.GetComponentInParent<PlayerHealth>().removeHealth(damageAmount);

            // Destroy the Bullet
            Destroy(gameObject);
        }        
    }
}
