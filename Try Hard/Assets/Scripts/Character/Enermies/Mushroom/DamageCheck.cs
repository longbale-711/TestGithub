using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            HeroHP.damageTaken = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        HeroHP.damageTaken = 0;
    }
}
