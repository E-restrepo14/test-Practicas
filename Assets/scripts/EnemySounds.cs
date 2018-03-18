using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    //en este script, decidi poner a sonar varios audios desde un mismo game object, utilizando el 
    //mismo audio source... y permitiendo que utilicen sus propios audioclips como argumentos para el subproceso que tiene dentro

    public AudioClip audioBuscando;
    
    public AudioClip audioAtaco;

    public AudioSource enemyAudiosource;

    
    void Start ()
    {
        enemyAudiosource = GetComponent<AudioSource>();
    }

    public void HacerRuido(AudioClip audioX)
    {
        enemyAudiosource.Stop();
        enemyAudiosource.clip = audioX;
        enemyAudiosource.volume = 0.8f;
        enemyAudiosource.Play();
    }
}
