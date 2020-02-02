using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    public Vector3 EndPoint;
    public bool DoMove = false;
    public float TimeToMove;
    private float TimeMoved;
    private Vector3 StartPoint;

    public void GoTo(Vector3 NewEndPoint)
    {
        StartPoint = transform.position;
        EndPoint = NewEndPoint;
        TimeMoved = 0.0f;
        DoMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartPoint = transform.position;
        TimeMoved = 0.0f;
        DoMove = false;
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

            // Lerp it into position linearly
            transform.position = Vector3.Lerp(StartPoint, EndPoint, Mathf.SmoothStep(0, 1.0f, TimeMoved / TimeToMove));
        }
    }
}
