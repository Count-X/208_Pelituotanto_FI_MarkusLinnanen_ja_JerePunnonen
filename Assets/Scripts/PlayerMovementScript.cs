using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the Movement of The Player

public class PlayerMovementScript : MonoBehaviour
{

    public float Speed = 1f;
    public float JumpForce = 1f;
    public float GroundCheckDistance = .1f;

    public Transform RaycastOrigin;
    public GroundCheckScript GroundCheck;


    // private default types here

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement to left and right
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, 0f)  * Speed * Time.deltaTime);

        // Jumping & Ground Check implementation
        if(Input.GetKeyDown(KeyCode.Space) && GroundCheck.OnGround)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Force);
        }

    }
}
