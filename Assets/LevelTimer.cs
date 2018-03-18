using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {
    public Text timerText;
    public float timeToComplete = 10f;
    private float timeleft;

    // Use this for initialization
    void Start ()
    {
        timeleft = timeToComplete;
        timerText.text = timeleft.ToString(); ;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeleft -= Time.deltaTime;
        timerText.text = Mathf.RoundToInt(timeleft).ToString();
        if (timeleft < 0)
        {
            if (CharController2D.isAlive)
            {
                CharController2D.Die();
            }
        }
	}
}
