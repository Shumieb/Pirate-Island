using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlayerHealth : MonoBehaviour
{

    [SerializeField] int healthPacks = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShip")
        {
            PlayerHealth playerHealthScript = collision.gameObject.GetComponentInParent<PlayerHealth>();                   
           
            // add health pack
            playerHealthScript.addHealthPack(healthPacks);

            // Destroy object
            Destroy(gameObject);
          
        }
    }
}
