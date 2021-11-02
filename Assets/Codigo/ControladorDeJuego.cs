using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDeJuego : MonoBehaviour
{
    public static ControladorDeJuego instancia;

    public float tiempoEntreAsteroides;
    private float tiempoCreacionAsteroide;

    public GameObject prefabAsteroide;

    public AudioSource musicaJuego;

    public Text textPuntaje;
    private int puntaje;

    public Text textGameOver;

    private bool jugando;

    void Start()
    {
        instancia = this;

        puntaje = 0;
        tiempoCreacionAsteroide = 0;

        textGameOver.gameObject.SetActive(false);
        jugando = true;

        musicaJuego.Play();
    }

    void Update()
    {
        if (jugando)
        {
            tiempoCreacionAsteroide += Time.deltaTime;
            Debug.Log("tiempoCreacionAsteroide: " + tiempoCreacionAsteroide);
            if (tiempoCreacionAsteroide >= tiempoEntreAsteroides)
            {
                //CREAR UN NUEVO ASTEROIDE
                tiempoCreacionAsteroide = 0;

                GameObject asteroide = Instantiate(prefabAsteroide);
                asteroide.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 6f, 2f);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Rejugar();
            }
        }
    }

    public void SumarPunto()
    {
        puntaje++;
        textPuntaje.text = "Asteroides: " + puntaje;
    }

    public void TerminarJuego()
    {
        jugando = false;
        textGameOver.gameObject.SetActive(true);
    }

    public void Rejugar()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
}
