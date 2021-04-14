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
    [SerializeField] Transform groundcheckCollider;
    [SerializeField] LayerMask groundLayer;
    GameObject temp;
    private BoxCollider2D boxCollider2D;
    public GameObject Dialogue;
    public Vector2 movement;
    //Int Values   
    private int direction;
    private int JumpCount;
    //Float Values
    [Header("FLOAT VALUES")]
    const float groundcheckRadius = 0.2f;
    public float GravityScale;
    public float Speed;
    public float JumpForce;

    public float TimeJumpEffect;
    public static float horizontal;

    //Bool Values
    private bool isGround;
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
            horizontal = Input.GetAxisRaw("Horizontal");
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Normal Jump
            if (isGround && JumpCount <= 0)
            {
                Jump();
                StartCoroutine(DestroyJumpEffect());
            }  
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "mushroom")
        {
            Dialogue.SetActive(true);
        }
    }
    //Animation
    public void SetAnimaition()
    {
        animator.SetBool("Run",!Mathf.Approximately(horizontal,0) && isGround);

        //Jump
        if ( isGround)
        {
            animator.SetBool("IsJumping",false); 
            animator.SetBool("IsFalling",false);
        }

        if (_rb.velocity.y > 2)
        {   
            animator.SetBool("IsJumping",true); 
        }

        if(_rb.velocity.y < 0)
        {
            animator.SetBool("IsJumping",false);
            animator.SetBool("IsFalling",true);
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
