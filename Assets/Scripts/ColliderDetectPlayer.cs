using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectPlayer : MonoBehaviour
{

    [SerializeField] bool playerInZone = false;
    [SerializeField] float damageAmount = 2f;

    private EnemyShoot EnemyShootScript;

    private void Awake()
    {
        EnemyShootScript = gameObject.GetComponentInParent<EnemyShoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerShip")
        {
            playerInZone = true;
            EnemyShootScript.SetPlayerInShotRange(playerInZone);

            // update damage amount
            EnemyDamageAmountManager.Instance.SetDamageAmount(damageAmount);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShip")
        {
            playerInZone = false;
            EnemyShootScript.SetPlayerInShotRange(playerInZone);
        }
    }

}
