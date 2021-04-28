using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHP : MonoBehaviour
{
    [Header("INT Value")]
    public int maxtHealth;
    public int currentHealth;
    public static int enermies;
    private int damaged;
    private bool isHurt = true;
    [Header("Float Value")]
    public float knockback;
    public float knockbackRange = 0.2f;
    private float knockbackCount;
    public float waitforDestroy;
    public float nexttimeHurt;
    [Header("Component")]
    public Rigidbody2D Rigidbody2D;
    public Animator animator1;
    public SetHealth setHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxtHealth;
        setHealth.SetMaxHealth(maxtHealth);
    }

    private void Update() {
        switch (enermies)
        {
            case 1: 
                damaged = 1;
                break; 
            case 2:
                damaged = 2;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enermies")
        {
            if (isHurt)
            {
                // Taking damage
                currentHealth -= damaged;
                setHealth.SetHp(currentHealth);
                if (currentHealth <= 0)
                {
                    Die();
                }
                else
                {
                    // Knockback
                    animator1.SetTrigger("IsHurt");
                    knockbackCount = knockbackRange;
                    Hurt();
                    isHurt = false;
                    Invoke("Reset",nexttimeHurt);
                }
            }  
        }
    }
    void Reset()
    {
        isHurt = true;
    }
    private void Hurt() {
        animator1.SetTrigger("IsHurt");
        // Knockback
        if (knockbackCount >= 0.2) 
        {
            if (!HeroController.isFaceRight )
            {
                Rigidbody2D.velocity = new Vector2(-knockback,knockback);
            }
            else if (HeroController.isFaceRight )
            {
                Rigidbody2D.velocity = new Vector2(knockback,knockback);
            }
        }
        knockbackCount -= Time.deltaTime; 
    
    }
    void Die()
    {
        //Die animation
        animator1.SetBool("IsDie",true);
        Destroy(gameObject,waitforDestroy);
        // GameOver Canvas 
        
    }
    

}
