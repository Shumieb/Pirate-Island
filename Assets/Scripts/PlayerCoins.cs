using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] int coinAmount = 0;

    public int getCoinAmount() { return coinAmount; }

    public void addCoinAmount(int value)
    {
        coinAmount += value;
    }

}
