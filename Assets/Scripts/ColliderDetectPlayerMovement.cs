using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectPlayerMovement : MonoBehaviour
{

    [SerializeField] bool playerInZone = false;

    private EnemyRoamingMovement EnemyRoamingMovement;

    private void Awake()
    {
        EnemyRoamingMovement = GetComponentInParent<EnemyRoamingMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInZone = true;
        EnemyRoamingMovement.SetPlayerInRange(playerInZone);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInZone = false;
        EnemyRoamingMovement.SetPlayerInRange(playerInZone);
    }
}
