using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpike : MonoBehaviour
{
    public Transform spawnspike;
    public GameObject spike;
    public float timeSpawnSpike;
    private float newSpawn = 0f;

    private void Update() {
        if (Time.time >= newSpawn)
        {
            SpikeSpawn();
            newSpawn = Time.time + timeSpawnSpike;
        }

        
    }


    void SpikeSpawn()
    {
        Instantiate(spike,spawnspike.position,spawnspike.rotation);
    }
}
