using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioClip MusicClipSthIsDestroyed;
    public AudioClip MusicClipGameLost;
    public AudioClip MusicClipGameWon;
    public AudioClip MusicClipCaught;
    public AudioSource MusicSource;
    public bool cont = true;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (cont)
        {
            if (!MusicSource.isPlaying)
            {
                MusicSource.Play();
            }
        }
    }

    public void SthIsDestroyed()
    {
        MusicSource.PlayOneShot(MusicClipSthIsDestroyed);
    }

    public void GameLost()
    {
        MusicSource.clip = MusicClipGameLost;
    }

    public void GameWon()
    {
        MusicSource.clip = MusicClipGameWon;
    }

    public void Caught()
    {
        MusicSource.PlayOneShot(MusicClipCaught);
    }
}
