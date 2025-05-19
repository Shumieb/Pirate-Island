using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    [SerializeField] Image slider;

    [SerializeField] GameObject damagedShip;

    [SerializeField] GameObject[] damageEffects;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {

        if (currentHealth <= 0)
        {
            // destroy Enemy
            gameObject.GetComponent<DestroyEnemy>().onDestroyEnemy();
        }
    }

    public void removeHealth(int value)
    {
        if (currentHealth > 0){ currentHealth -= value; }
        UpdateHealthBar();
        addDamageEffects();
    }

    private void UpdateHealthBar()
    {
        slider.fillAmount = currentHealth / maxHealth;
    }

    private void addDamageEffects()
    {
        float damageValue = (currentHealth / maxHealth);

        // set damage effect to active
        if(damageValue > 0.10 && damageValue <= 0.25)
        {
            if(!damageEffects[2].activeSelf) { damageEffects[2].SetActive(true); }
            if (!damageEffects[3].activeSelf) { damageEffects[3].SetActive(true); }            
            // show damaged ship
            if (!damagedShip.activeSelf) { damagedShip.SetActive(true); }
        }
        else if(damageValue >= 0.26 &&  damageValue <= 0.5)
        {
            if (!damageEffects[1].activeSelf) { damageEffects[1].SetActive(true); }
            // show damaged ship
            if (!damagedShip.activeSelf) { damagedShip.SetActive(true); }
        }
        else if(damageValue >= 0.55)
        {
            if (!damageEffects[0].activeSelf) { damageEffects[0].SetActive(true); }
        }
    }
}
