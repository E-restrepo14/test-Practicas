using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableScript : ClaseObjeto {

    //este script se encarga de subir y de bajar el score. dependiendo si el collectable aleatorio es capturado por 
    // el protagonista, o por el enemigo, tambien varia el audioclip que suena dentro del enemigo. y en ambos casos, se ordena 
    // instanciar otro collectable en una de los tantos posiciones disponibles instanciar una particula al ser destruidas enb un array de transforms.
   
    [SerializeField]
    private ParticleSystem particula;

    [SerializeField]
    private float volumen;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.instruccion1.SetActive(true);
            GameManager.Instance.InstanciarParticula();
            Destroy(gameObject);
            Instantiate(particula, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().estaHuyendo = true;
            GameManager.Instance.Alterarpuntaje(5);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.instruccion2.SetActive(true);
            GameManager.Instance.InstanciarParticula();
            enemy.GetComponent<EnemySounds>().HacerRuido(enemy.GetComponent<EnemySounds>().audioAtaco);
            Destroy(gameObject);
            GameManager.Instance.Alterarpuntaje(-3);

        }

    }
}
