using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] float shootValue = 0f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject cannonDir;

    [SerializeField] float shootWaitTime;
    [SerializeField] float maxShootWaitTime = 4f;

    [SerializeField] Vector2 cannonRotateInput;

    [SerializeField] private float rotateSpeed = 5f;

    void Start()
    {
        shootWaitTime = maxShootWaitTime + 1f;
    }

    void Update()
    {
        // update the shoot wait time until max wait time is reached
        if (shootWaitTime < maxShootWaitTime)
        {
            shootWaitTime += Time.deltaTime;
        }

        // rotate cannon
        shootPoint.transform.Rotate(new Vector3(0, 0, -cannonRotateInput.x * rotateSpeed * Time.deltaTime));

        // instantiate the bullet when the space bar is pressed and max shoot wait time is reached
        if ((shootValue >= 1) && (shootWaitTime >= maxShootWaitTime))
        {
            Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            // reset the shoot wait time
            shootWaitTime = 0;
        }

        if(cannonRotateInput.x != 0)
        {
            cannonDir.SetActive(true);
        }
        else
        {
            cannonDir.SetActive(false);
        }
        
    }

    // shoot the player bullet using the space bar
    public void Shoot(InputAction.CallbackContext context)
    {
        shootValue = context.ReadValue<float>();
    }

    // rotate the cannon using the n and m keys
    public void RotateCannon (InputAction.CallbackContext context)
    {
        cannonRotateInput = context.ReadValue<Vector2>();
    }

}
