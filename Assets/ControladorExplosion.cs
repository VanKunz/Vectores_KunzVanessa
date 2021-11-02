using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorExplosion : MonoBehaviour
{
    private float timer;
    public float tiempoDeVida = 0.2f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoDeVida)
        {
            Destroy(this.gameObject);
        }
    }
}
