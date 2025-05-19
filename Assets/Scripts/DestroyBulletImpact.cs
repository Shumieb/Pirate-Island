using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletImpact : MonoBehaviour
{

    [SerializeField] float timeToDestruction = 5f;

    private float countdownTimer = 0f;

    void Update()
    {
        // start timer
        if(countdownTimer < timeToDestruction) { 

            countdownTimer += Time.deltaTime;
        }
        else
        {
            // destroy object
            DestroyImpact();
        }
    }

    private void DestroyImpact()
    {
        Destroy(gameObject); 
    }
}
