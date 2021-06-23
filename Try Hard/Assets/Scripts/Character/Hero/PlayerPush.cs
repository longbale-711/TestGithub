using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public HeroController heroSpeed;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Stone"))
        {
            heroSpeed.Speed = 3f;
            Debug.Log("Helo");
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        heroSpeed.Speed = 6f;
    }
}
