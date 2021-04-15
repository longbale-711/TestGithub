using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoFlip : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroController.horizontal < 0)
        {
            sprite.flipX = true;
        }
        else if (HeroController.horizontal > 0)
        {
            sprite.flipX = false;
        }
    }
}
