using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Attached to every Projectile to decide its behaiviour when hitting the ground or player

public class ProjectileScript : MonoBehaviour
{

    public int ProjectileID;
    public int ProjectileTrashAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.CompareTag("Player"))
        {
            // Different Projectile Types
            switch (ProjectileID)
            {
                case 0:
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                case 1:
                case 2:
                case 3:
                    collision.gameObject.GetComponent<TrashScript>().TrashAmount += ProjectileTrashAmount;
                    Destroy(gameObject);
                    break;
            }
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
