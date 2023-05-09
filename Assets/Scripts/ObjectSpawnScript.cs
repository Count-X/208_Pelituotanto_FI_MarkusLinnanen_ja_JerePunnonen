using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;


// Script To Spawn Falling Projectiles (TBE (To Be Expanded))

public class ObjectSpawnScript : MonoBehaviour
{
    public GameObject[] ProjectilePrefabs;

    public float SpawnTime = 1f;

    Bounds SpawnBounds;

    float Timer;

    private void Start()
    {
        SpawnBounds = GetComponent<Collider2D>().bounds;
    }

    private void Update()
    {
        // Timer to spawn the Projectiles
        Timer += Time.deltaTime;
        if(Timer >= SpawnTime)
        {
            var PosInBounds = new Vector3(Random.Range(SpawnBounds.min.x, SpawnBounds.max.x), Random.Range(SpawnBounds.min.y, SpawnBounds.max.y), 0f);
            Instantiate(ProjectilePrefabs[Random.Range(0, ProjectilePrefabs.Length)], PosInBounds, transform.rotation,transform);
            Timer -= SpawnTime;
        }
    }

}
