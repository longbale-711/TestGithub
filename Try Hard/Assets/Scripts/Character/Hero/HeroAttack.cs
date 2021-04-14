using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [Header("Component")]
    public Animator _ani;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    // Int Values
    [Header("Set Attack Values")]
    public int attackDamage = 40;
    // Float Values
    public float waitControl = 0.2f;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    // Bool Values

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                Attack(); 
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        // Play attack animation
        _ani.SetTrigger("IsAttack");
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            // Set damage to enermy
            enemy.GetComponent<Mushroom_HP>().TakeDamage(attackDamage);
        }
    }

    
    void OnDrawGizmosSelected(){
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position , attackRange);
    }
}
