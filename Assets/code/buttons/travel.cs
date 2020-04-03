using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

    public void Human_Button()
    {
        SceneManager.LoadScene(1);

    }


    public void Intelectual_Button()
    {
        SceneManager.LoadScene(2);
    }


    public void Phisical_Button()
    {
        SceneManager.LoadScene(3);
    }


}
