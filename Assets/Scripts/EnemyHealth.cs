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

    private void Update()
    {
        if (currentHealth <= 0)
        {
            // destroy Enemy
            gameObject.GetComponent<DestroyEnemy>().onDestroyEnemy();
        }
    }

    public void removeHealth(float value)
    {
        if (currentHealth > 0){ currentHealth -= value; }                
    }
}
