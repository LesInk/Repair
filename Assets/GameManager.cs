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

    public Mover AllWalls;
    public Mover Floor;
    public Mover CelingLight;
    public Mover Stairs;

    public Mover Mountain;
    public Mover Props;
    public Mover Ground;
    public Mover Desk;

    public Mover Chair;

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
TextStatus.text = "Thank you\nProgramming - Lysle Shields\n3D Art - Jessica Cookson\n3D Art Assistance - Madeline Shields";
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
                    TextStatus.text = "More ...";
                    PlayerComputer.GoMove(2);
                    PlayerCabinet.GoMove(2);
                    break;
                case 9:
                    TextStatus.text = "Drink less coffee...";
                    PlayerCoffee.GoMove(1);
                    break;
                case 10:
                    PlayerCoffee.GoMove(2);
                    TextStatus.text = "A lot less coffee...";
                    break;
                case 11:
                    PlayerMonitor.GoMove(1);
                    TextStatus.text = "";
                    break;
                case 12:
                    TextStatus.text = "Open up...";
                    Ceiling.GoMove(0);
                    break;
                case 13:
                    TextStatus.text = "A bit more...";
                    Ceiling.GoMove(1);
                    break;
                case 14:
                    TextStatus.text = "Look down...";
                    Floor.GoMove(0);
                    break;
                case 15:
                    TextStatus.text = "Feel the ground...";
                    Floor.GoMove(1);
                    break;
                case 16:
                    PlayerMonitor.GoMove(2);
                    Ceiling.GoMove(2);
                    TextStatus.text = "Look to the sky...";
                    Floor.GoMove(2);
                    break;
                case 17:
                    TextStatus.text = "Go outside ...";
                    Ceiling.GoMove(3);
                    AllWalls.GoMove();
                    break;
                case 18:
                    TextStatus.text = "Look around ...";
                    Stairs.GoMove(0);
                    PlayerMonitor.GoMove(1);
                    break;
                case 19:
                    TextStatus.text = "Get more exercise ...";
                    Stairs.GoMove(1);
                    break;
                case 20:
                    TextStatus.text = "A little more exercise ...";
                    Stairs.GoMove(2);
                    break;
                case 21:
                    TextStatus.text = "Well something ...";
                    Stairs.GoMove(3);
                    break;
                case 22:
                    TextStatus.text = "This at least ...";
                    break;
                case 23:
                    TextStatus.text = "Breath In";
                    break;
                case 24:
                    TextStatus.text = "Breath Out";
                    break;
                case 25:
                    TextStatus.text = "Climb a mountain...";
                    Mountain.GoMove(0);
                    break;
                case 26:
                    TextStatus.text = "A bigger mountain...";
                    Mountain.GoMove(1);
                    break;
                case 27:
                    TextStatus.text = "Maybe bigger...";
                    Mountain.GoMove(2);
                    break;
                case 28:
                    TextStatus.text = "A big mountain!";
                    Mountain.GoMove(3);
                    break;
                case 29:
                    TextStatus.text = "Leave everything behind...";
                    Props.GoMove(0);
                    break;
                case 30:
                    TextStatus.text = "All of it...";
                    break;
                case 31:
                    TextStatus.text = "Especially the work...";
                    PlayerKeyboard.GoMove(1);
                    break;
                case 32:
                    TextStatus.text = "All of it...";
                    Desk.GoMove(0);
                    break;
                case 33:
                    TextStatus.text = "Remove yourself...";
                    Ground.GoMove(0);
                    Mountain.GoMove(4);
                    Chair.GoMove(0);
                    break;
                case 34:
                    TextStatus.text = "And be at peace...";
                    break;
                case 35:
                    TextStatus.text = "... peace ...";
                    break;
                case 36:
                    TextStatus.text = "Thank you\nProgramming - Lysle Shields\n3D Art - Jessica Cookson\n3D Art Assistance - Madeline Shields";
                    break;
                default:
                    TextStatus.text = "---";
                    Debug.Log("Unhandled state! " + State);
                    break;
            }
        }
    }
}
