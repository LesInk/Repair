using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFader : MonoBehaviour
{
    private bool IsFading;
    private Material WindowMaterial;
    private MeshRenderer Renderer;
    private float TimeToFade = 6.0f;
    private float TimeFaded = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        WindowMaterial = Renderer.materials[2];
    }

    public void FadeOut()
    {
        IsFading = true;
        TimeFaded = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFading)
        {
            TimeFaded += Time.deltaTime;
            if (TimeFaded >= TimeToFade)
            {
                IsFading = false;
            }

            Color C = WindowMaterial.color;
            C.a = Mathf.Lerp(1.0f, 0.1f, TimeFaded / TimeToFade);
            WindowMaterial.color = C;
        }
    }
}
