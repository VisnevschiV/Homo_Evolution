using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    public GameObject Versus_img;
    public float _speed;  
    private bool _moove;
    private Vector3 _target;

    // Update is called once per frame
    void Update()
    {
        // Aici e miscarea player-ului
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
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        _moove = false;
        Instantiate(Versus_img);
        _speed = 0;
    }
}
