using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    //fueron como las 2am cuando porfin terminé el juego, este resultó ser el script comodin.
    // lo modifique para que cumpla ciertas ordenes, pero al final terminó siendo muy confuso y feo, pues bueno disfrutenlo.

    public GameObject enemy;
    public AudioSource source;
    [SerializeField]
    private Text mytext;
    [SerializeField]
    private AudioClip grito;

    public void Awake()
    {
        //hasta me saco un error la belleza esta, pude cambiarlo igual... pero necesitaba dormir ya, bueno espero les haya gustado. un placer el tener esta experiencia.
         
        mytext.text = "your score: " + GameManager.Instance.score.ToString();
    }

    public void asustar()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = grito;
        GetComponent<AudioSource>().volume = 0.8f;
        GetComponent<AudioSource>().Play();
        enemy.GetComponent<EnemyMovement>().estaHuyendo = true;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("main");
    }

}
