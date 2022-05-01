using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghoul1 : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent ghoulAgent;
    private Animation ghoulAnim;
    private GameManager gameManager;

    private Vector3 position1 = new Vector3(25.8f, 0, -19.3f);
    private Vector3 position2 = new Vector3(8.31f, 0, 17.85f);
    private Vector3 position3 = new Vector3(1.46f, 0, 13.36f);

    private bool waiting;
    private float distance2Run = 18;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ghoulAgent = this.GetComponent<NavMeshAgent>();
        ghoulAnim = GetComponent<Animation>();
        waiting = true;


        transform.position = SetWaitingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance2Run)
        {
            waiting = false;
            ghoulAgent.isStopped = false;
            ghoulAgent.SetDestination(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
            ghoulAnim.Play("Walk");

            if (ghoulAgent.pathStatus == NavMeshPathStatus.PathPartial)
            {
                TryToOpenDoor(gameManager.keyCount);
            }
        }
        else
        {
            if (!waiting)
            {
                ghoulAgent.isStopped = false;
                ghoulAgent.SetDestination(SetWaitingPosition());
                ghoulAnim.Play("Walk");
                waiting = true;
            }
            if (ghoulAgent.remainingDistance != Mathf.Infinity && ghoulAgent.pathStatus == NavMeshPathStatus.PathComplete && ghoulAgent.remainingDistance == 0)
            {
                ghoulAgent.isStopped = true;
                ghoulAnim.Play("Idle");
            }
        }
    }

    Vector3 SetWaitingPosition()
    {
        int n = Random.Range(1, 3);

        switch (n)
        {
            case 1:
                return position1;
            case 2:
                return position2;
            default:
                return position3;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.GameOver();
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

    void TryToOpenDoor(int difficulty)
    {
        GameObject door = FindClosestDoor();
        int r;
        switch (difficulty)
        {
            case 0:
                break;
            case 1:
                r = Random.Range(1, 3);
                if (r == 1)
                {
                    door.transform.Find("Door_Wood").GetComponent<Door>().openDoor();
                }
                break;
            case 2:
                r = Random.Range(1, 2);
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
