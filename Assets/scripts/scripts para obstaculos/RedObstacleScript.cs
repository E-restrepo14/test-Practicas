using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObstacleScript : ClaseObjeto
{
   //este script ordena al gameobject en el que habita... acivar un booleano dentro del personaje enemigo

    [SerializeField]
    private AudioClip sonidoObstaculo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                        
            enemy.GetComponent<EnemyMovement>().estaPersiguiendo = true;
            enemy.GetComponent<EnemySounds>().HacerRuido(enemy.GetComponent<EnemySounds>().audioAtaco);
            source.Stop();
            source.clip = sonidoObstaculo;
            source.volume = 0.8f;
            source.Play();
            
        }
    }
}
