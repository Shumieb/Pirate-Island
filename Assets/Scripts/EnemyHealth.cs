using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void setHealth(float value)
    {
        currentHealth += value;

        if (currentHealth <= 0)
        {
            // destroy Enemy
            Debug.Log("Destroy Enemy");
        }
    }
}
