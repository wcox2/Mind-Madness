using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject player;
    public GameObject targetObject;
    private float targetAngle = 0;
    const float rotationAmount = 1.5f;
      
    
    void Start() {
        player = GameObject.FindWithTag("Player");
        targetObject = player.transform.GetChild(0).gameObject;
    }

    void Update()
    {
      
         // Trigger functions if Rotate is requested
         if (Input.GetKeyDown(KeyCode.LeftArrow)) {
             targetAngle -= 90.0f;
         } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
             targetAngle += 90.0f;
         }
      
         if(targetAngle !=0)
         {
             Rotate();
         }
     }
      
    protected void Rotate() {
        if (targetAngle>0) {
            transform.RotateAround(targetObject.transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if(targetAngle < 0) {
            transform.RotateAround(targetObject.transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }
    
    }
}
