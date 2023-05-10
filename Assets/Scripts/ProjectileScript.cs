using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Attached to every Projectile to decide its behaiviour when hitting the ground or player

public class ProjectileScript : MonoBehaviour
{

    public int ProjectileID;
    public int ProjectileTrashAmount;
    public float SideForce = 0.1f;

    Rigidbody2D rb;
    GameObject GM;
    TrashScript Trash;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager");
        Trash = GM.GetComponent<TrashScript>();
    }

    private void Update()
    {
        // Make it go left because a the Train moves forward so falling things seem like they go left
        rb.AddForce(new Vector2(SideForce * rb.mass, 0f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.gameObject.CompareTag("Player"))
        {
            // Different Projectile Types
            switch (ProjectileID)
            {
                case 0:
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    GM.GetComponent<GameManager>().GameOver("You got hit by Radioactive Waste");
                    break;
                case 1:
                case 2:
                case 3:
                    Trash.TrashAmount += ProjectileTrashAmount;
                    Destroy(gameObject);
                    break;
            }
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
