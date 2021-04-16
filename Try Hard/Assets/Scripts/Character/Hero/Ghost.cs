using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{    
    public static bool ghostAbi;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;

    // Update is called once per frame
    void Update()
    {
        //Ghost Ability
        if (HeroController.horizontal != 0 && ghostAbi)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position,Quaternion.identity);
                Destroy(instance,2f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        
    }
}
