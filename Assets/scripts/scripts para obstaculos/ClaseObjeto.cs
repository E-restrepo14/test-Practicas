using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseObjeto : MonoBehaviour {

    //tanto los obstaculos azules, como rojos, como instanciables aleatorios tienen unos comportamientos comunes
    // que es acceder tanto al mounstruo, como al jugador para modificar alguna variable... y hacer un ruido cuando detectan su collider
    // asi que para eso se creó esta clase, para que cada clase hija, herede de esta y sea mas facil de entender el codigo
    //igualmente me enrede e hice lo que pude como a la 1 am... asi que suerte entendiendo esta cosa.
    
    public AudioSource source;

    public GameObject enemy;
    public GameObject player;

    
    void Start () {
        source = GetComponent<AudioSource>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }

   
    public void HacerRuido(AudioClip audioX, float vol)
    {
        source.Stop();
        source.clip = audioX;
        source.volume = vol;
        source.Play();
    }

}
