using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ground Check with Collider (Unity did not agree with me on raycasts)

public class GroundCheckScript : MonoBehaviour
{
    [HideInInspector]
    public bool OnGround = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Train"))
        {
            OnGround = true;
        }
    }

    // Change from collision to Trigger (MEMO) (Delete This)

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Train"))
        {
            OnGround = false;
        }
    }
}
