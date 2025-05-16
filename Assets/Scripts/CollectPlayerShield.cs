using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayerShield : MonoBehaviour
{
    [SerializeField] float shieldUpTime = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShip")
        {
            // activate player shield
            collision.gameObject.GetComponentInParent<PlayerShieldManager>().activatePlayerShield(shieldUpTime);

            // Destroy object
            Destroy(gameObject);
        }
    }
}
