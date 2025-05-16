using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerShoot : MonoBehaviour
{

   // [SerializeField] bool canShoot = false;

    [SerializeField] float shootValue = 0f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;

    [SerializeField] float shootWaitTime;
    [SerializeField] float maxShootWaitTime = 4f;

    [SerializeField] float shootRightValue = 0f;
    [SerializeField] bool shootRight = false;

    [SerializeField] bool shootLeft = true;
    [SerializeField] float shootLeftValue = 1f;

    private Vector2 cannonRotateInput;

    [SerializeField] private float rotateSpeed = 5f;

    void Start()
    {
        shootWaitTime = maxShootWaitTime + 1f;
    }

    void Update()
    {
        if (shootWaitTime < maxShootWaitTime)
        {
            shootWaitTime += Time.deltaTime;
        }

        // rotate cannon
        shootPoint.transform.Rotate(new Vector3(0, 0, -cannonRotateInput.x * rotateSpeed * Time.deltaTime));

        if ((shootValue >= 1) && (shootWaitTime >= maxShootWaitTime))
        {
            Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            shootWaitTime = 0;
        }

        if(shootLeftValue >= 1)
        {
            shootLeft = true;
            shootRight = false;
        }

        if (shootRightValue >= 1)
        {
            shootLeft = false;
            shootRight = true;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        shootValue = context.ReadValue<float>();
    }

    public void RotateCannon (InputAction.CallbackContext context)
    {
        cannonRotateInput = context.ReadValue<Vector2>();
    }




    public void ShootRight(InputAction.CallbackContext context)
    {
        shootRightValue = context.ReadValue<float>();
    }

    public void ShootLeft(InputAction.CallbackContext context)
    {
        shootLeftValue = context.ReadValue<float>();
    }

    public string GetShootDirection()
    {
        if(shootLeft)
        {
            return "shootLeft";
        }

        if (shootRight)
        {
            return "shootLeft";
        }

        return "default";
    }
}
