using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    public Transform Toucher;
    private float GoalDistance = 0.1f;
    private MeshRenderer Renderer;

    private Color OriginalColor;
    private Color OriginalEmission;
    private Color TouchingEmission;
    private Color TouchingColor;
    private Color OldEmission;
    private Color OldColor;

    private bool IsOldMode = false;
    private bool IsTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        Color FullColor;
        Color HalfEmission;
        Color DarkEmission;
        Renderer = GetComponent<MeshRenderer>();
        OriginalColor = Renderer.material.color;
        OriginalEmission = Renderer.material.GetColor("_EmissionColor");

        DarkEmission.a = 0.01f;
        DarkEmission.r = 0;
        DarkEmission.g = 0;
        DarkEmission.b = 0;
        FullColor = OriginalColor;
        FullColor.a = 0f;
        HalfEmission = OriginalEmission;
        HalfEmission.a = 0.1f;
        HalfEmission.r = OriginalEmission.r / 2.0f;
        HalfEmission.g = OriginalEmission.g / 2.0f;
        HalfEmission.b = OriginalEmission.b / 2.0f;

        TouchingEmission = HalfEmission;
        TouchingColor = FullColor;

        OldEmission = DarkEmission;
        OldColor = FullColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Toucher != null)
        {
            IsTouching = ((Toucher.position - transform.position).magnitude < GoalDistance) ;

            if (IsOldMode)
            {
                Renderer.material.SetColor("_EmissionColor", OldEmission);
                Renderer.material.color = OldColor;
            }
            else
            { 
                if (IsTouching)
                {
                    Renderer.material.SetColor("_EmissionColor", TouchingEmission);
                    Renderer.material.color = TouchingColor;
                }
                else
                {
                    Renderer.material.SetColor("_EmissionColor", OriginalEmission);
                    Renderer.material.color = OriginalColor;
                }
            }
        }
    }

    public void SetOldMode(bool IsOld)
    {
        IsOldMode = IsOld;
    }

    public bool IsTouched()
    {
        return IsTouching;
    }
}
