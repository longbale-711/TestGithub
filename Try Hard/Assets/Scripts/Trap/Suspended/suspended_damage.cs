﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suspended_damage : MonoBehaviour
{
    public static bool suspend;
    public HeroHP knock;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            HeroHP.damageTaken = 2;
            knock.knockback = 20f;  

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        HeroHP.damageTaken = 0;
        knock.knockback = 6f;
    }

}
