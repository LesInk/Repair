using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPair : MonoBehaviour
{
    public TouchPoint[] Pair;
    private Focus FocusLeft;
    private Focus FocusRight;
    private bool DoFocus;

    // Start is called before the first frame update
    void Start()
    {
        Pair = GetComponentsInChildren<TouchPoint>();
    }

    public void SetOldMode(bool IsOld)
    {
        foreach(TouchPoint TP in Pair)
        {
            TP.SetOldMode(IsOld);
        }
    }

    public bool AreTouched()
    {
        bool Touched = true;
        foreach (TouchPoint TP in Pair)
        {
            if (!TP.IsTouched())
            {
                Touched = false;
            }
        }

        return Touched;
    }

    public void MoveFocus(Focus focusR, Focus focusL)
    {
        FocusLeft = focusL;
        FocusRight = focusR;
        DoFocus = true;
    }

    private void Update()
    {
        if (DoFocus)
        {
            if ((Pair[0].gameObject.transform != null) && (Pair[1].gameObject.transform != null))
            {
                FocusRight.GoTo(Pair[0].gameObject.transform.position);
                FocusLeft.GoTo(Pair[1].gameObject.transform.position);
                DoFocus = false;
            }
        }
    }
}
