using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPair : MonoBehaviour
{
    private TouchPoint[] Pair;

    // Start is called before the first frame update
    void Start()
    {
        Pair = GetComponentsInChildren<TouchPoint>();
    }

    public void SetPreviewMode(bool IsPreview)
    {
        foreach(TouchPoint TP in Pair)
        {
            TP.SetPreviewMode(IsPreview);
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
}
