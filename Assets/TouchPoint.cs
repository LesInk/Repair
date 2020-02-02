using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    private MeshRenderer Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color MyColor = Renderer.material.color;
        MyColor.a = 0f;
        Color EColor = Renderer.material.GetColor("_EmissionColor");
        EColor.a = 0.01f;
        EColor.r = 0;
        EColor.g = 0;
        EColor.b = 0;
        Renderer.material.SetColor("_EmissionColor", EColor);
        Renderer.material.color = MyColor;
    }
}
