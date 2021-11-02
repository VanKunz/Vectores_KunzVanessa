using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNave : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidad;

    public GameObject prefabBala;

    public GameObject puntoDeSpawnBalas;

    public AudioSource sonidoDisparo;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bala = Instantiate(prefabBala);
            bala.transform.position = new Vector3(puntoDeSpawnBalas.transform.position.x, puntoDeSpawnBalas.transform.position.y, 1f);

            sonidoDisparo.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(inputH, inputV);

        rigidbody.velocity = movimiento * velocidad;
    }

    private void LateUpdate()
    {
        float valorX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
        float valorY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);

        transform.position = new Vector3(valorX, valorY, transform.position.z);
        //Debug.Log("LateUpdate: " + valorX);
    }
}
