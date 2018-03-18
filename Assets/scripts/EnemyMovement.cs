using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    int tiempoOliendo = 2;
    private int tiempoEscondido = 3;
    float nextTime = 0;
    float nextTime2 = 0;
    private NavMeshAgent agent;

    public bool estaHuyendo = false;
    public bool estaPersiguiendo = false;

    [SerializeField]
    private Transform escaparate;
    [SerializeField]
    private Transform player;
    public GameObject[] waypoints;
    private int waypointInd;

    public float patrolSpeed = 0.5f;
    
    //este script se encarga de moctrolar la ia de lenemigo, por medio de booleanos. mediante de un update, el enemigo se comportará de cierto modo, se almacenaron varias
    //posiciones de la escena en arrays, para acceder despues a ellas y utilizarlas en codigo.
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("WaypointTag");
        waypointInd = Random.Range(0, waypoints.Length);
       
    }
	
    

	
	void Update ()
    {
        if (estaPersiguiendo == true)
        {
            Buscar();
        }

        if (estaHuyendo == true)
        {
            Ocultarse();
        }

        if (estaPersiguiendo == false && estaHuyendo == false)
        {
            Patrullar();
            //en caso de que el enemigo está patrullando y el jugador se acerque demaciado... el enemigo lo perseguirá
            if (Vector3.Distance(this.transform.position, player.position) <= 5)
            {
                Perseguir();
            }
        }
	}

    //en todos los estados del enemigo... patrullar, esconderse, buscar, perseguir... se varia la velocidad del navmesh agent que posee... y tambien varia el objetivo al que se diríge.

    public void Patrullar()
    {
        agent.speed = patrolSpeed;
        if (Vector3.Distance(this.transform.position,waypoints[waypointInd].transform.position) >= 2)
        {
            agent.SetDestination(waypoints[waypointInd].transform.position);
        }
        else
        if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
        {
            waypointInd = Random.Range(0, waypoints.Length);
        }
    }

    public void Ocultarse()
    {
        estaPersiguiendo = false;
        tiempoOliendo = 2;
        agent.speed = 4f;
        agent.SetDestination(escaparate.position);
        

        if (tiempoEscondido > 0)
        {
            if (Time.fixedTime > nextTime2)
            {
                nextTime2 = Time.fixedTime + 3;
                tiempoEscondido--;
            }
        }
        //en este script... todo funciona por medio de un update. asi que se utilizó mucho este metodo de dos if, con contadores.

        if (tiempoEscondido <= 0)
        {
            estaHuyendo = false;
            tiempoEscondido = 8;
        }
    }

    //dentro de este void, basicamente se busca darle un tiempo al jugador de alejarse del enemigo para evitar que ese inmediatamente se lance a buscarlo.
    public void Buscar()
    {
        if (tiempoOliendo > 0)
        {
            if (Time.fixedTime > nextTime)
            {
                nextTime = Time.fixedTime + 3;
                tiempoOliendo--;
            }
        }

        if (tiempoOliendo <= 0)
        {
            if (Vector3.Distance(this.transform.position, player.position) <= 20)
            {
                Perseguir();
            }
            else
            estaPersiguiendo = false;
            tiempoOliendo = 2;
        }
    }

    public void Perseguir()
    {

        agent.speed = 4f;
        agent.SetDestination(player.position);

        if (Vector3.Distance(this.transform.position,player.position) >= 2)
        {
            agent.SetDestination(player.position);
        }
        else
        if (Vector3.Distance(this.transform.position, player.position) <= 2)
        {
            GameManager.Instance.perdio = true;
        }
        

    }

    //en el momento que el jugador toca al enemigo, se acabó el juego.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.perdio = true;
        }
    }

    public void SeLeEscapo()
    {
        estaPersiguiendo = false;
        tiempoOliendo = 2;
    }




}
