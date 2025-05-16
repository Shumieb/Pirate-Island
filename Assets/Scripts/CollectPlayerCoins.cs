using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayerCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShip")
        {
            PlayerCoins playerCoinsScript = collision.gameObject.GetComponentInParent<PlayerCoins>();

            // add player coins
            playerCoinsScript.addCoinAmount(500);

            // Destroy object
            Destroy(gameObject);
        }
    }
}
