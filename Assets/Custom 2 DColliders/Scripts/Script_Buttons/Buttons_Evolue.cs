using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Evolue : MonoBehaviour
{
    public GameObject[] _buttons;

<<<<<<< HEAD
=======
    // Start is called before the first frame update
  

>>>>>>> origin/master
    public void Press()
    {
        
        foreach (var p in _buttons)
        {
            p.gameObject.SetActive(true);
        }
    }
}
