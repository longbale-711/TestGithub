using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHP : MonoBehaviour
{
    [Header("INT Value")]
    public int maxtHealth;
    public int currentHealth;
    public static int damageTaken;
    private int damaged;
    public static bool isHurt = true;
    [Header("Float Value")]
    public float knockback;
    public float knockbackRange = 0.2f;
    private float knockbackCount;
    public float waitforDestroy;
    public float knockbackTime;
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
        damaged = damageTaken;

        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enermies")
        {
            if (isHurt)
            {
                // Taking damage
                TakeDamaged(damaged);
                TimeHurt();
            }  
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap"))
        {
            if (Spike.spikecheck == true)
            {
                // Taking damage
                TakeDamaged(damaged);
                TimeHurt();
            }
            
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            gameObject.transform.position = new Vector3(117,-13,0);
        }
    }
    void TakeDamaged(int damage)
    {
        currentHealth -= damaged;
        setHealth.SetHp(currentHealth);
    }
    void TimeHurt()
    {
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                // Knockback
                animator1.SetTrigger("IsHurt");
                isHurt = false;
                knockbackCount = knockbackRange;
                GetComponent<HeroController>().enabled = false;
                Hurt();
                StartCoroutine(waitKnockBack());
            }
    }
    IEnumerator waitKnockBack()
    {
        yield return new WaitForSeconds(knockbackTime);
        GetComponent<HeroController>().enabled = true;
        yield return new WaitForSeconds(nexttimeHurt);
        isHurt = true;
        knockback = 6f;
    }

    public void Hurt() {
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
