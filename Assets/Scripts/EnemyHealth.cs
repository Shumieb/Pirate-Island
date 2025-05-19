using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    [SerializeField] Image slider;

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

    public void removeHealth(float value)
    {
        if (currentHealth > 0){ currentHealth -= value; }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        slider.fillAmount = currentHealth / maxHealth;
    }

}
