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
    private Color NoEmission;
    private Color HighlightColor;
    private bool IsPreviewing = false;
    private bool IsTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        OriginalColor = Renderer.material.color;
        OriginalEmission = Renderer.material.GetColor("_EmissionColor");
        NoEmission.a = 0.01f;
        NoEmission.r = 0;
        NoEmission.g = 0;
        NoEmission.b = 0;
        HighlightColor = OriginalColor;
        HighlightColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Toucher != null)
        {
            IsTouching = ((Toucher.position - transform.position).magnitude < GoalDistance) ;

            if (IsPreviewing)
            {
                Color PreviewEmission = OriginalEmission;
                PreviewEmission.a = 0.1f;
                PreviewEmission.r = OriginalEmission.r / 2.0f;
                PreviewEmission.g = OriginalEmission.g / 2.0f;
                PreviewEmission.b = OriginalEmission.b / 2.0f;
                Renderer.material.SetColor("_EmissionColor", PreviewEmission);
                Renderer.material.color = OriginalColor;
            }
            else
            { 
                if (IsTouching)
                {
                    Renderer.material.SetColor("_EmissionColor", NoEmission);
                    Renderer.material.color = HighlightColor;
                }
                else
                {
                    Renderer.material.SetColor("_EmissionColor", OriginalEmission);
                    Renderer.material.color = OriginalColor;
                }
            }
        }
    }

    public void SetPreviewMode(bool IsPreview)
    {
        IsPreviewing = IsPreview;
    }

    public bool IsTouched()
    {
        return IsTouching;
    }
}
