using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxLives = 3;
    [SerializeField] int currentLives;

    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    void Start()
    {
        currentLives = maxLives;     
        currentHealth = maxHealth;
    }

    public int getCurrentLives() { return currentLives; }

    public void setLives(int value){
        currentLives += value;

        if(currentLives <= 0)
        {
            // destroy player
            // game over
            Debug.Log("Game Over");
        }
    }

    public float getHealth() { return currentHealth;}

    public void setHealth(float value) {  
        currentHealth += value;

        if(currentHealth <= 0)
        {
            setLives(-1);
        }
    }
}
