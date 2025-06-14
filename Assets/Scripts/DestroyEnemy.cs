using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{

    [SerializeField] string rewardBuffName;

    private GameObject rewardPrefab;

    private void Start()
    {
        rewardPrefab = PlayerRewardManager.Instance.GetPlayerRewardPrefab(rewardBuffName);
    }

    public void onDestroyEnemy()
    {
        //place Reward
        Instantiate(rewardPrefab, transform.position, Quaternion.identity);

        // destroy Enemy
        Destroy(gameObject);
    }
}