using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Moving : MonoBehaviour
{
    [SerializeField] private GameObject _traces;
    private bool _moove;
    private Vector3 _target;
    private bool _finish = true;
    public GameObject Versus_img;
    public float speed;
    private Quaternion rotate;


    void Update()
    {
        Vector2 directionPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(directionPoint.y, directionPoint.x) * Mathf.Rad2Deg;
        rotate = Quaternion.AngleAxis(angle-90, Vector3.forward);
        if (Input.GetMouseButtonDown(0))
        {
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
            _target.z = transform.position.z;
            if(_moove == false)
            {
                _moove = true;
            }
        }
        if(_moove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
           TracesInstantiate(_finish);
        }

    }

    private void TracesInstantiate(bool finish)
    {
        
        if (finish == true)
            StartCoroutine(Treas());
        _finish = false;
    }

    IEnumerator Treas()
    {

        Instantiate(_traces, transform.position, rotate);
        yield return new WaitForSeconds(0.5f);
        _finish = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        _moove = false;
        Versus_img.SetActive(true);
        speed = 0;
    }
}
