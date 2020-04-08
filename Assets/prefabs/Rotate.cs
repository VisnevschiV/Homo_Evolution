using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
            
            
                Vector2 directionPoint = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position) - transform.position;
                float angle = Mathf.Atan2(directionPoint.y, directionPoint.x) * Mathf.Deg2Rad;
                Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = rotate;
                Debug.Log(transform.rotation);
            
        
       
    }
}
