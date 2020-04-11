using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Random_Pozition : MonoBehaviour
{
    [SerializeField] private int maxX;
    [SerializeField] private int minX;
    [SerializeField] private int maxY;
    [SerializeField] private int minY;
    [SerializeField] private int speed;

    [SerializeField] private GameObject _traces;
    private Quaternion rotate;

    [SerializeField] private int breakMaxX;
    [SerializeField] private int breakMinX;
    [SerializeField] private int breakMaxY;
    [SerializeField] private int breakMinY;

    private int likelyToBreakTheLimit;

    private bool reachPoint=true;
    void Update()
    {
        likelyToBreakTheLimit = Random.Range(-1, 101);
        if (likelyToBreakTheLimit <= 5)
        {
            if (reachPoint == true)
            {
                reachPoint = !reachPoint;
                int breakX = Random.Range(breakMinX, breakMaxX);
                int breakY = Random.Range(breakMinY, breakMaxY);
                Vector2 directionPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(directionPoint.y, directionPoint.x) * Mathf.Rad2Deg;
                rotate = Quaternion.AngleAxis(angle, Vector3.forward);
                StartCoroutine(StartMove(breakX,breakY));
            }
            else
            {
                reachPoint = false;
            }

            
        }
        else
        {
            if (reachPoint == true)
            {
                
                reachPoint = !reachPoint;
                int randomX = Random.Range(minX, maxX);
                int randomY = Random.Range(minY, maxY);
                Vector2 directionPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(directionPoint.y, directionPoint.x) * Mathf.Rad2Deg;
                rotate = Quaternion.AngleAxis(angle, Vector3.forward);
                
                StartCoroutine(StartMove(randomX, randomY));
            }
            else
            {
                StartCoroutine(Start());
                reachPoint = false;
            }
        }
    }

    IEnumerator StartMove(int pozitionX, int pozitionY)
    {
        
        Vector2 distance=new Vector2(pozitionX,pozitionY);
        while (Vector2.Distance(transform.position, distance) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, distance, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        reachPoint = true;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Treas());
    }

    IEnumerator Treas()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(_traces, transform.position, rotate);
       
    }
}
