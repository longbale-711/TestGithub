using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            DialogueText.nextSentences = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        DialogueText.nextSentences = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
