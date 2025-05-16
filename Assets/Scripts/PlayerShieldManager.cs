using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShieldManager : MonoBehaviour
{

    [SerializeField] bool shieldActive = false;

    [SerializeField] int shieldCount = 0;

    [SerializeField] float shieldMaxUpTime = 15.0f;
    [SerializeField] float shieldUpTime;

    [SerializeField] GameObject shield;

    private float shieldActivated = 0f;

    private void Awake()
    {
        shield.SetActive(shieldActive);
    }

    void Update()
    {
        if (shieldActivated >= 1 && !shieldActive)
        {
            activatePlayerShield();
        }

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

    private void activatePlayerShield()
    {
        Debug.Log("activated");
        if(shieldCount > 0)
        {
            shieldActive = true;
        }
        else
        {
            // display message to say no shields available
            Debug.Log("no shield available");
        }
    }

    public void addShield(int shieldNum)
    {
        shieldCount += shieldNum;
    }

    public void ActivateShield(InputAction.CallbackContext context)
    {
        shieldActivated = context.ReadValue<float>();
    }
}
