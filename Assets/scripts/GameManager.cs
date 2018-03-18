using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject instanciadoAleatorio;
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private AudioClip galloCantando;
    [SerializeField]
    private AudioSource cerdoOliendo;
    [SerializeField]
    private AudioSource pisadas;

    float i = 0f;
    [SerializeField]
    private Light amanecerLight;

    public static GameManager Instance;
    public float tiempoLimite = 120f;
    public int score = 5;

    public bool perdio = false;
    public bool gano = false;

    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Image winSprite;
    [SerializeField]
    private Image looseSprite;
    public Text scoreText;

    public GameObject instruccion1;

    public GameObject instruccion2;

    // este singleton se encarga de mostrar algunos elementos que conforman toda la interfaz de usuario, lo que 
    //viene siendo el timer, el texto del score, y algunos botones de las leyendas que surgen en el canvas

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        cerdoOliendo = GetComponent<AudioSource>();
        pisadas = GetComponent<AudioSource>();
        amanecerLight = GetComponent<Light>();

    }

    public void InstanciarParticula()
    {
        Instantiate(instanciadoAleatorio, waypoints[Random.Range(0, waypoints.Length)].position, Quaternion.identity);
    }

    public void quitar()
    {
        Application.Quit();
    }

    public void Alterarpuntaje(int puntos)
    {
        score += puntos;
        scoreText.text = "Score: " + score.ToString();
    }

    //========================================================================================

    void Update()
    {
            tiempoLimite -= Time.deltaTime;

        //por medio de un timer... se decidirá cuando el juego acaba... en caso de que se llegue a 0, significa que ganó

        if (tiempoLimite > 0)
        {
            tiempoText.text = "tiempo limite: " + tiempoLimite.ToString("f0");


        }

      //este subproceso es mas de embellecimiento de la escena, simulando un amanecer.

        if (tiempoLimite < 1)
        {
            winSprite.gameObject.SetActive (true);
            amanecerLight.color = new Color(i, i, i);
            if (i < 0.8)
            {
                i += 0.005f;
            }

            if (i == 0.010f)
            {
                pisadas.Stop();
                pisadas.clip = galloCantando;
                pisadas.volume = 0.8f;
                pisadas.Play();

                cerdoOliendo.Stop();
                cerdoOliendo.clip = galloCantando;
                cerdoOliendo.volume = 0.8f;
                cerdoOliendo.Play();
                Time.timeScale = 0;
            }
            
        }

        if (perdio == true)
        {
            looseSprite.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }

    

}

