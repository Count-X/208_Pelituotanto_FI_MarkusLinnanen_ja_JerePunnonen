using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 1f;
    public float TurnSpeed = 1f;

    void Update()
    {
        transform.Translate(new Vector3( 0f, Input.GetAxis("Vertical"), 0f)  * Speed * Time.deltaTime);

        if (Input.GetAxis("Vertical") >= 0.1f)
        {
            transform.Rotate(0f, 0f, -Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime);
        }
    }
}
