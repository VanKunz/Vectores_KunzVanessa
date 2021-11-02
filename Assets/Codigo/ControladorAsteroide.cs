using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAsteroide : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidad;
    private float velocidadRotacion;

    public GameObject prefabExplosion;

    void Start()
    {
        rigidbody.velocity = new Vector2(0, -velocidad);
        velocidadRotacion = Random.Range(-3f, 3f);
        //velocidadRotacion = Random.Range(-3, 3);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocidadRotacion));

        if (transform.position.y <= -6f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: " + collision.gameObject);
        if (collision.CompareTag("Nave"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            ControladorDeJuego.instancia.TerminarJuego();
        }

        if (collision.CompareTag("Bala"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            ControladorDeJuego.instancia.SumarPunto();
        }

        GameObject explosion = Instantiate(prefabExplosion);
        explosion.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
    }
}
