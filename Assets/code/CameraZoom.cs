using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Vector3 _touchStart;
    private float zoomOutMin = 1;
    private float zoomOutMax = 8;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevos - touchOnePrevos).magnitude;
            float curentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float diference = curentMagnitude - prevMagnitude;
           zoom(diference * 0.001f);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }

    public void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
