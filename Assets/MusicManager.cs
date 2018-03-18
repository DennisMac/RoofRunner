using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioClip stage1;
    public AudioClip stage2;
    public static MusicManager Instance = null;
    private AudioSource musicAudio;
    public int level = 1;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        musicAudio = theSource;
    }

    public void SwapClip()
    {
        if (++level % 2 == 0)
        {
            musicAudio.Stop();
            musicAudio.clip = stage2;
            musicAudio.Play();
        }
        else
        {
            musicAudio.Stop();
            musicAudio.clip = stage1;
            musicAudio.Play();
        }
           
    }
}
