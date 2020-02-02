using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Audio;
    private float NextBongSound;
    private float FirstBongSound = 13.759f;
    private float BongInterval = 6.8865f/1.0f;
    public int BongCount;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        NextBongSound = FirstBongSound;
        BongCount = -1;
    }

    public void SkipTo(float TimeInMusic)
    {
        if (TimeInMusic < FirstBongSound)
        {
            BongCount = 0;
            NextBongSound = FirstBongSound;
        }
        else
        {
            NextBongSound = FirstBongSound;
            while (NextBongSound <= TimeInMusic)
            {
                BongCount++;
                NextBongSound += BongInterval;
            }
        }
        // Now skip to the song position
        Audio.time = TimeInMusic;
    }


    public void StartMusic()
    {
        Audio.Play();
        Debug.Log("Music started");
//SkipTo(30.0f);
    }

    public bool UpdateMusic(bool IsTouching, bool IsDoneAllPoints)
    {
        bool DoNext = false;
        float TimeAt = Audio.time; // where are we in the song?
        if (TimeAt >= NextBongSound)
        {
            // Time for the next bong sound, did we touch the goal points in time?
            if (IsTouching)
            {
                // Yes, touching, well, let's move to the next one (continuing if we are paused)
                Audio.UnPause();
                NextBongSound += BongInterval;
                BongCount++;
                DoNext = true;
//Debug.Log("BongCount: " + BongCount);
            }
            else
            {
                // Time for next bong, BUT we are not touching, or there are no more
                if (!IsDoneAllPoints)
                {
                    Audio.Pause();
                }
            }
        }

        return DoNext;
    }
}
