using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLoader : MonoBehaviour
{
    public Animator animator;
    public static bool FadeScene;

    // Update is called once per frame
    void Update()
    {
        if (FadeScene)
        {
            animator.SetTrigger("ScreenFade");
        }
    }
}
