using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;

    //private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 rotateInput;

    void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        //move player
        transform.position += transform.up * moveInput.y * moveSpeed * Time.deltaTime;
        
        // rotate ship
       transform.Rotate(new Vector3(0, 0, -rotateInput.x * rotateSpeed * Time.deltaTime));        
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<Vector2>();   
    }

}
