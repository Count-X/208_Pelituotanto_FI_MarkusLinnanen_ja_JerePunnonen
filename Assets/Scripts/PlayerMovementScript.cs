using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the Movement of The Player

public class PlayerMovementScript : MonoBehaviour
{

    public Transform RaycastOrigin;
    public GroundCheckScript GroundCheck;

    public float Speed = 1f;
    public float JumpForce = 1f;

    // private default types here

    Rigidbody2D rb;
    Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Turning the player, in too many lines
        bool left = Input.GetAxis("Horizontal") <= 0f;
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = Input.GetAxis("Horizontal") == 0f ? rotationVector.y : (left ? 180f : 0f);
        transform.rotation = Quaternion.Euler(rotationVector);

        // Movement to left and right
        transform.Translate(new Vector3((left ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal")), 0f, 0f) * Speed * Time.deltaTime);

        anim.SetBool("Walking", Input.GetAxis("Horizontal") != 0f);

        // Jumping & Ground Check implementation
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck.OnGround)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Force);
        }


        anim.SetBool("Jumping", !GroundCheck.OnGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.instance.GameOver("You fell off the Train");
            Destroy(gameObject);
        }
    }
}
