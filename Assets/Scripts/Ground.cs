using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour {
    public Sprite bw;
    public Sprite color;
    private SpriteRenderer spriteRenderer;
    public static List<Ground> allColorChangers;


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
            allColorChangers.Remove(this);
            if (allColorChangers.Count == 0)
            {
                Manager.Instance.LevelComplete();
                
            }
        }
    }

    
}
