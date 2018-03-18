using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObstacleScript : ClaseObjeto
{
  // este script. se encarga de interrumpir el subproceso de persecucion del enemigo hacia el jugador 
  //cada vez que este entra al collider del game object dueño de este script

    [SerializeField]
    private AudioClip sonidoObstaculo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            enemy.GetComponent<EnemyMovement>().estaPersiguiendo = false;
            enemy.GetComponent<EnemySounds>().HacerRuido(enemy.GetComponent<EnemySounds>().audioAtaco);
            source.Stop();
            source.clip = sonidoObstaculo;
            source.volume = 0.8f;
            source.Play();

        }
    }
}
