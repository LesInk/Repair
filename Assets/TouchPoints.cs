using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoints : MonoBehaviour
{
    public TouchPair[] Pairs;
    public int ActivePair = 0;
    private int _ActivePair = -1;
    public Focus FocusR;
    public Focus FocusL;
    public bool IsDone;

    // Start is called before the first frame update
    void Start()
    {
        Pairs = GetComponentsInChildren<TouchPair>();
        ActivePair = 0;
        _ActivePair = -1;
        IsDone = false;
    }

    void UpdateActives()
    {
        if (ActivePair != _ActivePair)
        {
            bool NeverFound = true;
            _ActivePair = ActivePair;
            Debug.Log("Active pair now " + ActivePair);
            for (int i = 0; i < Pairs.Length; i++)
            {
                if (i == ActivePair)
                {
                    Pairs[i].gameObject.SetActive(true);
                    Pairs[i].SetOldMode(false);

                    // Move focus to the new pair's position
                    Pairs[i].MoveFocus(FocusR, FocusL);
                    NeverFound = false;
                }
                else if (i == ActivePair - 1)
                {
                    Pairs[i].gameObject.SetActive(true);
                    Pairs[i].SetOldMode(true);
                }
                else
                {
                    Pairs[i].gameObject.SetActive(false);
                }
            }
            if ((NeverFound == true) && (ActivePair > 0))
            {
                IsDone = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateActives();
    }

    public bool CheckTouched()
    {
        bool IsTouched = false;

        if ((_ActivePair >= 0) && (_ActivePair < Pairs.Length))
        {
            if (Pairs[_ActivePair].AreTouched())
            {
                IsTouched = true;
            }
        }

        return IsTouched;
    }

    public void DoNext()
    {
        ActivePair++;
        UpdateActives();
    }
}
