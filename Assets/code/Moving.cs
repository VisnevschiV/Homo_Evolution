using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.U2D;

public class Moving : MonoBehaviour
{
    [SerializeField] private GameObject _traces;
    [SerializeField] private GameObject _ObjectRotate;
    private bool _moove;
    private Vector3 _target;
    private bool _finish = true;
    public GameObject Versus_img;
    public float speed;


    void Update()
    {
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

        Instantiate(_traces, transform.position, _ObjectRotate.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        _finish = true;
    }

    float AngleBetweenTwoPoints(float a, float b)
    {
        return Mathf.Atan2(b,a) * Mathf.Rad2Deg;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        _moove = false;
        Versus_img.SetActive(true);
        speed = 0;
    }
}
