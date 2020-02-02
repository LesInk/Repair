using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TouchPoints TouchPointsManager;
    public MusicManager Music;

    // Start is called before the first frame update
    void Start()
    {
        Music.StartMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Music.UpdateMusic(TouchPointsManager.CheckTouched(), TouchPointsManager.IsDone))
        {
            TouchPointsManager.DoNext();
        }

    }
}
