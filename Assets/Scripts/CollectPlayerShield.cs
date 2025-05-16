using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayerShield : MonoBehaviour
{
    [SerializeField] int shieldToAdd = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShip")
        {
            // activate player shield
            collision.gameObject.GetComponentInParent<PlayerShieldManager>().addShield(shieldToAdd);

            // Destroy object
            Destroy(gameObject);
        }
    }
}
