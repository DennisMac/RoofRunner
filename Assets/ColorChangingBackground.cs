using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingBackground : MonoBehaviour {
    Color finalColor;
    public Color startColor = Color.white;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        finalColor = spriteRenderer.color;
        spriteRenderer.color = startColor;
        Ground.Scored += Ground_Scored;
	}
    void OnDestroy()
    {
        Ground.Scored -= Ground_Scored;
    }


    private void Ground_Scored(object sender, scoredEventArgs e)
    {
        spriteRenderer.color = Color.Lerp(startColor, finalColor, e.percentage);
    }

}
