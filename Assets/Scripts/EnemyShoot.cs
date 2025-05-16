using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] bool playerInShotRange = false;

    [SerializeField] bool canShoot = false;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;

    [SerializeField] float shootWaitTime;
    [SerializeField] float maxShootWaitTime = 4f;

    private void Start()
    {
        shootWaitTime = maxShootWaitTime + 1f;
    }

    void Update()
    {
        if (playerInShotRange)
        {            
                canShoot = true;
        }
        else
        {
            canShoot= false;
        }

        if(shootWaitTime < maxShootWaitTime)
        {
            shootWaitTime += Time.deltaTime;
        }

        if(canShoot && (shootWaitTime >= maxShootWaitTime))
        {
            Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
            shootWaitTime = 0;
        }
    }

    public void SetPlayerInShotRange(bool value)
    {
        playerInShotRange = value;
    }
}
