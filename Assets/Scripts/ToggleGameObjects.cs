using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObjects : MonoBehaviour {
   public GameObject[] gameObjects;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (gameObjects[0].activeSelf)
            {
                gameObjects[0].SetActive(false);
                gameObjects[1].SetActive(true);
            }
            else
            {
                gameObjects[0].SetActive(true);
                gameObjects[1].SetActive(false);
            }
        }
	}
}
