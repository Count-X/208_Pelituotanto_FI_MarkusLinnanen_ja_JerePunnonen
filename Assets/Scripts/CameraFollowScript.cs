using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This Script is used for making the Camera follow The Player but ignore the players Rotation making turning more clear

public class CameraFollowScript : MonoBehaviour
{

    public Transform Player;

    public float CameraY;

    private void Update()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x, Player.position.y, CameraY);
        }
        else Destroy(this);
    }
}
