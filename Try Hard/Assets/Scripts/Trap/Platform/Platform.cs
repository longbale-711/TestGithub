using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float PlatformSpeed;
    public int target;
    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, PlatformSpeed * Time.deltaTime);
    }
    private void FixedUpdate() {
        if (transform.position == waypoints[target].position)
        {
            if (target == waypoints.Count - 1)
            {
                
                target = 0;
            }
            else
            {
                target += 1;
        
            }
        }
        
    }
}
