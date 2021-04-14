using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHP : MonoBehaviour
{
    [Header("INT Value")]
    public static int maxtHealth = 10;
    public int currentHealth;
    [Header("Float Value")]
    public float knockback;
    public float knockbackRange = 0.2f;
    private float knockbackCount;
    public float TimeDelay;
    public float HurtTime = 1f;
    public float waithurting = 0.5f;
    public float waitforDestroy;
    private float nexttimeHurt;
    private bool isDie;
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


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "mushroom")
        {
            if (Time.time >= nexttimeHurt)
            {
                // Taking damage
                currentHealth -= 1;
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
                }
                nexttimeHurt = Time.time;
            }
        }

        if (other.tag == "HighCheck")
        {
            CameraController.highCheck = true;
        }
    }
    void Die()
    {
        //Die animation
        animator1.SetBool("IsDie",true);
        Destroy(gameObject,waitforDestroy);
        // GameOver Canvas 
        
    }
    

}
