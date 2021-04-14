using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public static bool highCheck = false;
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Debug.LogError("TARGET IS NULL!!");
            return;
        }

        if (!highCheck)
        {
            Vector3 newPosition = new Vector3(target.position.x,transform.position.y,-10);
            transform.position = newPosition;
        }
        else if (highCheck)
        {
            Vector3 newPosition = new Vector3(target.position.x,target.position.y,-10);
            transform.position = newPosition;
        }
    }
}
