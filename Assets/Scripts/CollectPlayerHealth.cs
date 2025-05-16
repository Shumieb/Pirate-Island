using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayerHealth : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShip")
        {
            PlayerHealth playerHealthScript = collision.gameObject.GetComponentInParent<PlayerHealth>();

            // check health value
            float playerMaxHealthValue = playerHealthScript.getCurrentHealth();
            float playerCurrentHealthValue = playerHealthScript.getCurrentHealth();
           
            if(playerCurrentHealthValue < playerMaxHealthValue)
            {
                // add player health
                playerHealthScript.addHealth(2);
                // Destroy object
                Destroy(gameObject);
            }
            else
            {
                // add message on the canvas
                Debug.Log("Max Health reached");
            }     
           
        }
    }
}
