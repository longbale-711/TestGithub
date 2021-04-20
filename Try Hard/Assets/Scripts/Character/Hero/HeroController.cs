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
    public GameObject E;
    public GameObject Taking;
    public GameObject Room1;
    [SerializeField] Transform groundcheckCollider;
    [SerializeField] LayerMask groundLayer;
    GameObject temp;
    private BoxCollider2D boxCollider2D;
    public GameObject Dialogue;
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
    private bool isGround;
    private bool isDoor;
    public static bool canMove = true;
    public static bool isFaceRight;

    
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        Room1.SetActive(false);
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
        
        if (isDoor && Input.GetKeyDown(KeyCode.E))
        {
            _rb.transform.position = new Vector3(-44,46,0);
            Room1.SetActive(true);
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dialog")
        {
            Dialogue.SetActive(true);
            canMove = false;
            Speed = 0f;
        }

        if (other.tag == "Door")
        {
            isDoor = true;
            if (isDoor)
            {
                E.SetActive(true);
            }
        }

        if (other.tag == "Tutorial")
        {
            Taking.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        isDoor = false;
        Taking.SetActive(false);
        E.SetActive(false);
        
    }
    //Animation
    public void SetAnimaition()
    {
        animator.SetBool("Run",!Mathf.Approximately(horizontal,0) && isGround && canMove);

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
