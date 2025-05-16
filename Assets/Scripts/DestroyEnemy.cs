using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{

    [SerializeField] GameObject rewardPrefab;


    public void onDestroyEnemy()
    {
        //place Reward
        Instantiate(rewardPrefab, transform.position, Quaternion.identity);

        // destroy Enemy
        Destroy(gameObject);
    }
}