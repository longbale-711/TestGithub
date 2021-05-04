using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suspended_damage : MonoBehaviour
{
    public HeroHP heroHP;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            heroHP.knockback = 20f;
            heroHP.Hurt();
            Debug.Log("Lo");
        }
    }
}
