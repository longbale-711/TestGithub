﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_HP : MonoBehaviour
{
    public int maxHP;
    int currentHp;
    private float dazedTime;
    public float startDazedTime;
    public float WaitDieAni;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHP;
    }

    private void Update() {
        if (dazedTime <= 0)
        {
            GetComponent<Mushroom_AI>().MushroomSpeed = 5f;
        }
        else {
            GetComponent<Mushroom_AI>().MushroomSpeed = 0f;
            dazedTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        //dazed
        dazedTime = startDazedTime;

        //Take Damage
        currentHp -= damage;
        
        //Play hurt animation
        animator.SetTrigger("Hurt");
        
        //Die animation
        if (currentHp <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        GetComponent<Mushroom_AI>().enabled = false;
        //Die animation
        animator.SetBool("IsDie",true);
        //Disable the enermy
        Destroy(gameObject,WaitDieAni);
    }
}
