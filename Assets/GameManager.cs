using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TouchPoints TouchPointsManager;
    public MusicManager Music;
    public int State;
    public Text TextStatus;

    public WindowFader FrontWindow;
    public WindowFader FrontWindow2;

    public Mover PlayerComputer;
    public Mover PlayerCabinet;
    public Mover PlayerMonitor;
    public Mover PlayerKeyboard;
    public Mover PlayerCoffee;

    public Mover Ceiling;

    // Start is called before the first frame update
    void Start()
    {
        Music.StartMusic();
        State = -1;
Debug.Log("Starting with State " + Music.BongCount);
        TouchPointsManager.DoIndex(Music.BongCount);
        if (TouchPointsManager.ActivePair != 0)
        {
            UpdateState(TouchPointsManager.ActivePair);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Music.UpdateMusic(TouchPointsManager.CheckTouched(), TouchPointsManager.IsDone))
        {
            TouchPointsManager.DoNext();
            UpdateState(TouchPointsManager.ActivePair);
        }
    }

    void UpdateState(int NewState)
    {
        while (State < NewState)
        {
            State++;
            switch (State)
            {
                case 0:
                    TextStatus.text = "Touch the Spheres";
                    break;
                case 1:
                    TextStatus.text = "Breath In";
                    break;
                case 2:
                    TextStatus.text = "Breath Out";
                    break;
                case 3:
                    TextStatus.text = "Breath In";
                    break;
                case 4:
                    TextStatus.text = "Breath Out";
                    break;
                case 5:
                    FrontWindow.FadeOut();
                    FrontWindow2.FadeOut();
                    TextStatus.text = "Look outside";
                    break;
                case 6:
                    PlayerComputer.GoMove(0);
                    PlayerCabinet.GoMove(0);
                    PlayerMonitor.GoMove(0);
                    PlayerKeyboard.GoMove(0);
                    PlayerCoffee.GoMove(0);
                    TextStatus.text = "Lighten up...";
                    break;
                case 7:
                    TextStatus.text = "";
                    PlayerComputer.GoMove(1);
                    PlayerCabinet.GoMove(1);
                    break;
                case 8:
                    PlayerComputer.GoMove(2);
                    PlayerCabinet.GoMove(2);
                    Ceiling.GoMove(0);
                    break;
                case 9:
                    Ceiling.GoMove(1);
                    break;
                default:
                    TextStatus.text = "???";
                    Debug.Log("Unhandled state! " + State);
                    break;
            }
        }
    }
}
