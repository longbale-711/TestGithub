using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeKey : MonoBehaviour
{
    public GameObject KeyHole;
    public GameObject Gate;
    public float WaitForOpen;
    public static bool OpenGate = false;
    private bool key;
    private void Update() {
        if (key && Input.GetKeyDown(KeyCode.E))
        {
            KeyHole.GetComponent<Animator>().enabled = true;
            Gate.GetComponent<Animator>().SetTrigger("IsClose");
            StartCoroutine(waitForOpenGate());
            OpenGate = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            key = true;
        }
    }

    IEnumerator waitForOpenGate()
    {
        yield return new WaitForSeconds(WaitForOpen);
        Gate.SetActive(false);
        OpenGate = false;
    }

}
