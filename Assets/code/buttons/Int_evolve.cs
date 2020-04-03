using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Int_evolve : MonoBehaviour
{
    public GameObject info;
    public GameObject Evolve_button;
	GameObject[] all;

    // Update is called once per frame
    public void onClick()
    {
		all = GameObject.FindGameObjectsWithTag ("text");
		foreach (GameObject t in all) {
			t.SetActive (false);
		}
        Evolve_button.SetActive(true);
        info.SetActive(true);
	}

}
