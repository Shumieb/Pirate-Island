using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{

    public void OnDestroyPlayer()
    {

        Debug.Log("Destroy player");
        Debug.Log("Game Over");

        // Destroy(gameObject); 
    }
}
