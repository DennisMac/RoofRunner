using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public static Manager Instance;
    public GameObject levelCompleteText;

	// Use this for initialization
	void Start ()
    {
        Instance = this;
        Ground.allColorChangers = new List<Ground>( FindObjectsOfType<Ground>());
	}

    public void LevelComplete()
    {
        levelCompleteText.SetActive(true);
        Time.timeScale = 0.01f;
        StartCoroutine(LevelComplete(0.03f));
    }

    IEnumerator LevelComplete(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 1f;
        int nextScene = int.Parse(SceneManager.GetActiveScene().name) + 1;
        SceneManager.LoadScene(nextScene.ToString());
    }

}
