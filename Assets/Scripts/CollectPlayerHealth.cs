using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayerHealth : MonoBehaviour
{

    [SerializeField] float healthToAdd = 10.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShip")
        {
            PlayerHealth playerHealthScript = collision.gameObject.GetComponentInParent<PlayerHealth>();

            // check health value
            float playerMaxHealthValue = playerHealthScript.getMaxHealth();
            float playerCurrentHealthValue = playerHealthScript.getCurrentHealth();
           
            if(playerCurrentHealthValue < playerMaxHealthValue)
            {
                // add player health
                playerHealthScript.addHealth(healthToAdd);
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
