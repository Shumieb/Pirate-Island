using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBulletMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5.0f;

    [SerializeField] bool shootRight = false;
    [SerializeField] bool shootLeft = true;

    private PlayerShoot playerShootScript;

    private string shootDirection = "shootLeft";


    private void Awake()
    {
        playerShootScript = FindObjectOfType<PlayerShoot>();
    }

    void Start()
    {
        shootDirection = playerShootScript.GetShootDirection();
    }

    void Update()
    {
        if(shootDirection == "shootLeft" || shootDirection == "default")
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        if (shootDirection == "shootRight")
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
    }

}
