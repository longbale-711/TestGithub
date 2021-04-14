using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public Rigidbody2D PlatformTrans;
    private bool isUp;
    public float SpeedPlatform;
    

    // Start is called before the first frame update
    void Start()
    {
        PlatformTrans = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        if (isUp)
        {
            PlatformTrans.velocity = Vector2.up * SpeedPlatform;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bottom")
        {
            isUp = true;
        }
        else if (other.tag == "Top")
        {
            isUp = false;
        }
    }
}
