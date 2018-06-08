using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject sphere1, sphere2, sphere3, sphere4, sphere5, sphere6,sphere7;

	void Start () {
        VerificaObjetos();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void VerificaObjetos() {
        if (PlayerPrefs.GetInt("Sphere1", 0) == 1) {
            Destroy(sphere1);
        }

        if (PlayerPrefs.GetInt("Sphere2", 0) == 1)
        {
            Destroy(sphere2);
        }

        if (PlayerPrefs.GetInt("Sphere3", 0) == 1)
        {
            Destroy(sphere3);
        }

		if (PlayerPrefs.GetInt("Sphere4", 0) == 1)
		{
			Destroy(sphere4);
		}

		if (PlayerPrefs.GetInt("Sphere5", 0) == 1)
		{
			Destroy(sphere5);
		}

		if (PlayerPrefs.GetInt("Sphere6", 0) == 1)
		{
			Destroy(sphere6);
		}

		if (PlayerPrefs.GetInt("Sphere7", 0) == 1)
		{
			Destroy(sphere7);
		}
    }
}
