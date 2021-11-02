using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBala : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidad;

    void Start()
    {
        rigidbody.velocity = new Vector2(0, velocidad);
    }

    void Update()
    {
        if (transform.position.y >= 6f)
            Destroy(this.gameObject);
    }
}
