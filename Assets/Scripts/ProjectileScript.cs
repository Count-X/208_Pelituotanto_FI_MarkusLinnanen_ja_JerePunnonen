using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Script Attached to every Projectile to decide its behaiviour when hitting the ground or player

public class ProjectileScript : MonoBehaviour
{

    public AudioClip ProjectileAudioClip;

    public int ProjectileID;
    public int ProjectileTrashAmount;
    public float SideForce = 0.1f;
    public float OnGroundTime = 1f;

    Rigidbody2D rb;
    GameObject GM;
    TrashScript Trash;

    bool inAir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager");
        Trash = GM.GetComponent<TrashScript>();
        inAir = true;
    }

    private void Update()
    {
        // Make it go left (if in air) because a the Train moves forward so falling things seem like they go left
        if(inAir) rb.AddForce(new Vector2(SideForce * rb.mass, 0f));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        
        if (other.gameObject.CompareTag("Player"))
        {
            // Different Projectile Types
            switch (ProjectileID)
            {
                case 0:
                    AudioManager.instance.PlayAudio(ProjectileAudioClip);
                    Destroy(other.gameObject);
                    GameManager.instance.GameOver("You got hit by Radioactive Waste");
                    break;
                case 1:
                case 2:
                case 3:
                    Trash.TrashAmount += ProjectileTrashAmount;
                    AudioManager.instance.PlayAudio(ProjectileAudioClip);
                    Destroy(gameObject);
                    break;
            }
        }
        else if (other.gameObject.CompareTag("Train"))
        {
            inAir = false;
            switch (ProjectileID)
            {
                case 0:
                    Destroy (gameObject);
                    break;
                case 1:
                case 2:
                case 3:
                    StartCoroutine("StaysOnGround");
                    break;
            }
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StaysOnGround()
    {
        for(float f = 0f; f < OnGroundTime; f += Time.deltaTime)
        {
            // Forgot this bit so pulled from https://github.com/Count-X/CarGameMobile/blob/main/Assets/CarControls.cs (my own code =) )
            yield return null;

        }
        Destroy(gameObject);
    }
}
