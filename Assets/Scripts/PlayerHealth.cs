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

    private void Update()
    {
        if (currentHealth <= 0) 
        { 
            // remove health
            removeLives(1);

            // reset health
            currentHealth = maxHealth;
        }
       
        if (currentLives <= 0)
        {
            // destroy player
            gameObject.GetComponent<DestroyPlayer>().OnDestroyPlayer();
        }
    }

    public int getLives() { return currentLives; }

    public void addLives(int value)
    {
        if(currentLives < maxLives) { currentLives -= value; }
    }

    public void removeLives(int value)
    {
        if (currentLives > 0){ currentLives -= value; }        
    }

    public float getMaxHealth() { return maxHealth; }

    public float getCurrentHealth() { return currentHealth;}

    public void addHealth(float value)
    {
        if (currentHealth < maxHealth){ currentHealth += value;}
    }

    public void removeHealth(float value) {  
        if(currentHealth > 0) { currentHealth -= value;}    
    }
}
