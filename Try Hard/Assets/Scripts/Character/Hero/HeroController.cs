using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour
{
    //Component
    [Header("Component")]
    public Rigidbody2D _rb;
    public SpriteRenderer _sr;
    public Animator animator;
    public SceneManager _Sm;
    public Transform spawnJumpEffect;
    public GameObject JumpEffect;
    public GameObject player;
    [SerializeField] Transform groundcheckCollider;
    [SerializeField] LayerMask groundLayer;
    GameObject temp;
    Vector2 movement;
    
    //Int Values   
    private int JumpCount;
    //Float Values
    [Header("FLOAT VALUES")]
    const float groundcheckRadius = 0.2f;
    public float GravityScale;
    public float Speed;
    public float JumpForce;
    public float dashSpeed;
    public float TimeJumpEffect;
    
    public static float horizontal;

    //Bool Values
    private bool isJump;
    private bool isFall;
    private bool isGround;
    private bool isPlatform;
    public static bool canMove = true;
    public static bool isFaceRight;

    
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // GravitySacle Value
        _rb.gravityScale = GravityScale;
        // Movement
            if (canMove)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
            }
            
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            //Normal Jump
            if (isGround && JumpCount <= 0)
            {
                Jump();
                StartCoroutine(DestroyJumpEffect());
            }  
        }

        if (!canMove)
        {
            Speed = 0f;
        }
        else 
        {
            Speed = 6f;
        }
        SetAnimaition();
    }
    
    
    private void FixedUpdate() {
        movement = new Vector2(horizontal * Speed,_rb.velocity.y);
        _rb.velocity = movement;
        GroundCheck();
    }

    void GroundCheck(){
        isGround = false;

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(groundcheckCollider.position,groundcheckRadius,groundLayer);
        if (collider2Ds.Length > 0)
        {
            isGround = true;
            
        }
    }
    void Jump()
    {
        _rb.AddForce(Vector2.up * JumpForce,ForceMode2D.Impulse);
    }
    IEnumerator DestroyJumpEffect()
    {
        temp = Instantiate(JumpEffect,spawnJumpEffect.position,spawnJumpEffect.rotation);
        yield return new WaitForSeconds(TimeJumpEffect);
        Destroy(temp);
    }

    // Flip character
    void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.Rotate(0f,180f,0f);
    }

    //Collision Objects
    private void OnCollisionEnter2D(Collision2D hitGround) {
        if (hitGround.gameObject.CompareTag("Ground"))
        {
            JumpCount = 0;
            JumpForce = 25f;
        }
        if (hitGround.transform.tag == "Platform")
        {
            this.transform.parent = hitGround.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        this.transform.parent = null;
    }
    
    //Animation
    public void SetAnimaition()
    {
        animator.SetBool("Run",!Mathf.Approximately(horizontal,0) && isGround && canMove);

        //Jump
        if ( isGround)
        {
            isJump = false;
            isFall = false;
            animator.SetBool("IsJumping",isJump); 
            animator.SetBool("IsFalling",isFall);
        }

        if (_rb.velocity.y > 2)
        {   
            isJump = true;
            animator.SetBool("IsJumping",isJump); 
        }

        if(_rb.velocity.y < 0 && isPlatform == false)
        {
            isJump = false;
            isFall = true;
            animator.SetBool("IsJumping",isJump);
            animator.SetBool("IsFalling",isFall);
        }
        //FLIP
        if (horizontal > 0 && isFaceRight)
        {
            Flip();
        }
        else if (horizontal < 0 && !isFaceRight)
        {
            Flip();
        }
    
    }  

    
    
}
