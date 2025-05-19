using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{

    [SerializeField] float damageAmount = 2.0f;

    [SerializeField] GameObject impactPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShield")
        {
            // Destroy the Bullet
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerShip")
        {
            // instatiate impact
            Instantiate(impactPrefab, transform.position, transform.rotation);

            // update damage amount
            damageAmount = EnemyDamageAmountManager.Instance.GetDamageAmount();

            // Deduct health from the player
            collision.gameObject.GetComponentInParent<PlayerHealth>().removeHealth(damageAmount);

            // Destroy the Bullet
            Destroy(gameObject);
        }        
    }
}
