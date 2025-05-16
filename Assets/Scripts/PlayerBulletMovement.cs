using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBulletMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5.0f;

    void Update()
    {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

}
