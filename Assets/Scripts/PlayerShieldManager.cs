using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldManager : MonoBehaviour
{

    [SerializeField] bool shieldActive = false;

    [SerializeField] float shieldMaxUpTime = 0.1f;
    [SerializeField] float shieldUpTime;

    [SerializeField] GameObject shield;

    private void Awake()
    {
        shield.SetActive(shieldActive);
    }

    void Update()
    {
        if (shieldActive && shieldUpTime < shieldMaxUpTime)
        {
            // activate shield
            shield.SetActive(shieldActive);
            shieldUpTime += Time.deltaTime;
        }

        if(shieldActive && shieldUpTime >= shieldMaxUpTime)
        {
            shieldActive = false;
            // deactivate shield
            shield.SetActive(shieldActive);
        }
    }

    public void activatePlayerShield(float maxUpTime)
    {
        shieldMaxUpTime += maxUpTime;
        shieldActive = true;
    }
}
