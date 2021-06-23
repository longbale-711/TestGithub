using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour
{
    public Spike spikeSpeed;
    public BoxCollider2D box;
    private void Update() {
        if (Spike.spikecheck == false)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            box = GetComponent<BoxCollider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            spikeSpeed.SpikeSpeed = 30f;

        }

        if (other.tag == "Trap")
        {
            box.isTrigger = false;
        }
    }

    
}
