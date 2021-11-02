using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFondo : MonoBehaviour
{
    public MeshRenderer meshQuad;
    public float velocidad = 2f;
    private float offsetY;

    void Start()
    {
        
    }

    void Update()
    {
        offsetY += Time.deltaTime;

        meshQuad.material.mainTextureOffset = new Vector2(0, offsetY * velocidad);
    }
}
