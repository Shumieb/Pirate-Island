using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewardManager : MonoBehaviour
{

    [SerializeField] GameObject healthBuffPrefab;
    [SerializeField] GameObject shieldBuffPrefab;
    [SerializeField] GameObject chestBuffPrefab;

    [SerializeField] int healthBuffCount;
    [SerializeField] int shieldBuffCount;
    [SerializeField] int chestBuffCount;

    private static PlayerRewardManager _instance;

    public static PlayerRewardManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public GameObject GetPlayerRewardPrefab(string rewardName)
    {
        switch (rewardName)
        {
            case "healthBuff":
                healthBuffCount++;
                return healthBuffPrefab;
            case "shieldBuff":
                shieldBuffCount++;
                return shieldBuffPrefab;
            case "chestBuff":
                chestBuffCount++;
                return chestBuffPrefab;
            default: return null;
        }

    }

}
