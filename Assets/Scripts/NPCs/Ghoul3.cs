using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghoul3 : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent ghoulAgent;
    private Animation ghoulAnim;
    private GameManager gameManager;

    private Vector3 position1 = new Vector3(-18.7f, 14.7f, 16.6f);
    private Vector3 position2 = new Vector3(-1, 14.7f, 14.7f);
    private Vector3 position3 = new Vector3(24.3f, 14.7f, -7.4f);
    private Vector3 position4 = new Vector3(24.3f, 14.7f, -18.4f);
    private Vector3 position5 = new Vector3(-33.2f, 14.7f, -9.9f);

    private Vector3 destination;

    private bool waiting;
    private float distance2Run = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ghoulAgent = this.GetComponent<NavMeshAgent>();
        ghoulAnim = GetComponent<Animation>();
        waiting = true;


        destination = SetWaitingPosition();
        transform.position = destination;
        ghoulAgent.Warp(transform.position);
        ghoulAnim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        //se comprueba si el juego está en pausa
        if (gameManager.pause)
        {
            ghoulAgent.isStopped = true;    //el NPC se detiene
            ghoulAnim.Play("Idle");         //animación a reproducir
        }
        else
        {
            //se comprueba si el jugador está en rango
            if (Vector3.Distance(transform.position, player.transform.position) < distance2Run)
            {
                //se comprueba si el destino es alcanzable
                if (ghoulAgent.pathStatus == NavMeshPathStatus.PathPartial & waiting)
                {
                    TryToOpenDoor(gameManager.keyCount);
                }

                waiting = false;                //el NPC deja de estar en espera
                ghoulAgent.isStopped = false;   //el NPC está en movimiento

                //el jugador es el objetivo del NPC
                ghoulAgent.SetDestination(new Vector3(player.transform.position.x,
                    this.transform.position.y, player.transform.position.z));

                ghoulAnim.Play("Walk");         //animación a reproducir
            }
            else
            {
                //se determina 1 vez una posición aleatoria
                if (!waiting)
                {
                    ghoulAgent.isStopped = false;
                    destination = SetWaitingPosition();
                    ghoulAnim.Play("Walk");
                    waiting = true;
                }

                ghoulAgent.SetDestination(destination);

                //se comprueba si la posición es alcanzable
                if (ghoulAgent.pathStatus == NavMeshPathStatus.PathPartial)
                    destination = SetWaitingPosition(); //se define nueva posición

                //se comprueba si el NPC ha alcanzado el objetivo
                if (Vector3.Distance(destination, transform.position) < 0.5 &&
                    ghoulAgent.remainingDistance != Mathf.Infinity &&
                    ghoulAgent.pathStatus == NavMeshPathStatus.PathComplete &&
                    ghoulAgent.remainingDistance == 0)
                {
                    ghoulAgent.isStopped = true;       //el NPC se detiene
                    ghoulAnim.Play("Idle");            //animación a reproducir
                }
            }
        }

    }

    Vector3 SetWaitingPosition()
    {
        int n = Random.Range(1, 6);

        switch (n)
        {
            case 1:
                return position1;
            case 2:
                return position2;
            case 3:
                return position3;
            case 4:
                return position4;
            default:
                return position5;

        }
    }



    public GameObject FindClosestDoor()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Door");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void TryToOpenDoor (int difficulty)
    {
        GameObject door = FindClosestDoor();
        int r;
        switch (difficulty)
        {
            case 0:
                break;
            case 1:
                r = Random.Range(0, 3);
                if (r == 1)
                {
                    door.transform.Find("Door_Wood").GetComponent<Door>().openDoor();
                }
                break;
            case 2:
                r = Random.Range(0, 2);
                if (r == 1)
                {
                    door.transform.Find("Door_Wood").GetComponent<Door>().openDoor();
                }
                break;
            case 3:
                door.transform.Find("Door_Wood").GetComponent<Door>().openDoor();
                break;
        }
    }
}
