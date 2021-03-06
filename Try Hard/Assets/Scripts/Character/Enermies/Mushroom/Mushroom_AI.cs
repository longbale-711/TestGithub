using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_AI : MonoBehaviour
{
    // public | private | protected + float | bool | int,... + tenvalue
    public float MushroomSpeed;
    public float distance;
    private bool movingRight = true;
    public static bool mushroom;
    public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * MushroomSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
        if (groundInfo.collider == false){
            if (movingRight == true){
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }

        
    }


}
