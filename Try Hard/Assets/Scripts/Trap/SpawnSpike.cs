using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpike : MonoBehaviour
{
    public GameObject spike;
    public Transform spawnSpike;
    public float waitforanima;
    private bool playerhit = false;
    // Start is called before the first frame update
    void Start()
    {

        
        
    }
    private void Update() {
        if (playerhit == true)
        {
            StartCoroutine(waitFOrani());
            playerhit = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    IEnumerator waitFOrani()
    {
        yield return new WaitForSeconds(waitforanima);
        Debug.Log("Lo");
        Instantiate(spike,spawnSpike.position,spawnSpike.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            GetComponent<Animator>().enabled = true;
            playerhit = true;
        }
    }
}
