using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform End;
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private Vector3 StartScale;
    private bool DoMove = false;
    private float TimeToMove = 5.0f;
    private float TimeMoved = 0.0f;

    public List<Transform> Ends;

    // Start is called before the first frame update
    void Start()
    {
        StartRotation = transform.rotation;
        StartPosition = transform.position;
        StartScale = transform.localScale;
    }

    public void GoMove(int EndIndex=-1)
    {
        if (EndIndex != -1)
        {
            End = Ends[EndIndex];
        }

        DoMove = true;
        TimeMoved = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoMove)
        {
            TimeMoved += Time.deltaTime;
            if (TimeMoved >= TimeToMove)
            {
                TimeMoved = TimeToMove;
                DoMove = false;
            }

        }
        float t = Mathf.SmoothStep(0, 1.0f, TimeMoved / TimeToMove);
        transform.rotation = Quaternion.Lerp(StartRotation, End.rotation, t);
        transform.position = Vector3.Lerp(StartPosition, End.position, t);
        Vector3 NewScale = Vector3.Lerp(StartScale, End.localScale, t);
        if (NewScale.magnitude >= 0.001f)
        {
            transform.localScale = NewScale;
        }
        else
        {
            // Else turn off
            gameObject.SetActive(false);
        }


        if (!DoMove)
        {
            // Make this the new start
            StartRotation = transform.rotation;
            StartPosition = transform.position;
            StartScale = transform.localScale;
        }
    }
}
