using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Evolue : MonoBehaviour
{
    public GameObject[] _buttons;

    // Start is called before the first frame update
  

    public void Press()
    {
        
        foreach (var p in _buttons)
        {
            p.gameObject.SetActive(true);
        }
    }
}
