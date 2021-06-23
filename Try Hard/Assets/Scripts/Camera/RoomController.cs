using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomController : MonoBehaviour
{
    public GameObject virtualCam;
    public Transform Groom;
    public Transform openGate;
    private CinemachineVirtualCamera virtualCamera;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);

        }
    }

    private void Update() {
        if (TakeKey.OpenGate == true)
        {
            virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = openGate;
        }
    }

}   
