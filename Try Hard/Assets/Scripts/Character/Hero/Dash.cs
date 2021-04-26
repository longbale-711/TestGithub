using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    public float DashCoolDown;
    public float DashRange;
    private bool canDash = true;

    public Rigidbody2D dashRigid;
    public CapsuleCollider2D capsuleCollider;
    public Animator animator;
    private void Start() {
        dashRigid = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            if (!HeroController.isFaceRight)
            {
                GetComponent<HeroController>().enabled = false;
                capsuleCollider.enabled = false;
                dashRigid.AddForce(Vector2.right * dashSpeed,ForceMode2D.Impulse);
                animator.SetTrigger("IsDash");
            }
            else if (HeroController.isFaceRight)
            {
                GetComponent<HeroController>().enabled = false;
                capsuleCollider.enabled = false;
                dashRigid.AddForce(Vector2.left * dashSpeed,ForceMode2D.Impulse); 
                animator.SetTrigger("IsDash");
            }

            canDash = false;
            
            StartCoroutine(Dashing());
        }

        
    }
    IEnumerator Dashing()
    {
        yield return new WaitForSeconds(DashRange);
        GetComponent<HeroController>().enabled = true;
        capsuleCollider.enabled = true;
        yield return new WaitForSeconds(DashCoolDown);
        canDash = true;
    }
}
