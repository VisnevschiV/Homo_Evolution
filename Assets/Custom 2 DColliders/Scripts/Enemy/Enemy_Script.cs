using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    [SerializeField] private float _distanceToAtack;
     private  GameObject _player;
    [SerializeField] private float _speed;

    public void Start()
    {
        _player=GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.localPosition, _player.transform.position) < _distanceToAtack)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, _player.transform.position,
                _speed * Time.deltaTime);
        }
    }
}
