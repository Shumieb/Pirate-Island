using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerBullet : MonoBehaviour
{

    [SerializeField] int damageAmount = 2;

    [SerializeField] GameObject impactPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip")
        {

            // instatiate impact
            Instantiate(impactPrefab, transform.position, transform.rotation);

            // Deduct health from the Enemy
            collision.gameObject.GetComponent<EnemyHealth>().removeHealth(damageAmount);

            // Destroy the Bullet
            Destroy(gameObject);

        }

        if(collision.gameObject.tag == "EnemyBullet")
        {
            // instatiate impact
            Instantiate(impactPrefab, transform.position, transform.rotation);

            // destroy enemy bullet
            Destroy(collision.gameObject);

            // destroy object
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShootRange")
        {
            // destroy bullet
            Destroy(gameObject);
        }
    }
}
