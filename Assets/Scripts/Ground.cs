using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scoredEventArgs : EventArgs
{
    public float percentage { get; set; }
    public scoredEventArgs(float percentage)
    {
        this.percentage = percentage;
    }

}

public class Ground : MonoBehaviour {
    public Sprite bw;
    public Sprite color;
    private SpriteRenderer spriteRenderer;
    public static List<Ground> allColorChangers;

    public static event EventHandler<scoredEventArgs> Scored;
    public static float total = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = color;
        }
        if (allColorChangers.Contains(this))
        {
            Scored(this, new scoredEventArgs( Mathf.Clamp((4+total-allColorChangers.Count)/total, 0f, 1f)));

            allColorChangers.Remove(this);
            if (allColorChangers.Count == 0)
            {
                Manager.Instance.LevelComplete();
            }
        }
    }

    
}
