using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectPlayer : MonoBehaviour
{

    [SerializeField] bool playerInZone = false;

    [SerializeField] GameObject currentEnemy;

    [SerializeField] EnemyShoot EnemyShootScript;

    private void Awake()
    {
        EnemyShootScript = currentEnemy.GetComponent<EnemyShoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInZone = true;
            EnemyShootScript.SetPlayerInShotRange(playerInZone);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInZone = false;
            EnemyShootScript.SetPlayerInShotRange(playerInZone);
        }
    }


}
