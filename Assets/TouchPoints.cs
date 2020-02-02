using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoints : MonoBehaviour
{
    public TouchPair[] Pairs;
    public int ActivePair = 0;
    private int _ActivePair = -1;

    // Start is called before the first frame update
    void Start()
    {
        Pairs = GetComponentsInChildren<TouchPair>();
        ActivePair = 0;
        _ActivePair = -1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouched();

        if (ActivePair != _ActivePair)
        {
            _ActivePair = ActivePair;
            Debug.Log("Active pair now " + ActivePair);
            for (int i = 0; i < Pairs.Length; i++)
            {
                if (i == ActivePair)
                {
                    Pairs[i].gameObject.SetActive(true);
                    Pairs[i].SetPreviewMode(false);
                }
                else if (i == ActivePair + 1)
                {
                    Pairs[i].gameObject.SetActive(true);
                    Pairs[i].SetPreviewMode(true);
                }
                else
                {
                    Pairs[i].gameObject.SetActive(false);
                }
            }
        }
    }

    void CheckTouched()
    {
        if ((_ActivePair >= 0) && (_ActivePair < Pairs.Length))
        {
            if (Pairs[_ActivePair].AreTouched())
            {
                ActivePair++;
            }
        }
    }
}
