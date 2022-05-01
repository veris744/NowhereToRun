using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crawler2 : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent crawlerAgent;
    private Animator crawlerAnim;
    private GameManager gameManager;

    private Vector3 position1 = new Vector3(136.2f, 0, 17);
    private Vector3 position2 = new Vector3(95.2f, 0, 3.6f);
    private Vector3 position3 = new Vector3(106.3f, 0, -15.1f);

    private bool waiting;
    private float distance2Run = 18;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        crawlerAgent = this.GetComponent<NavMeshAgent>();
        crawlerAnim = GetComponent<Animator>();
        waiting = true;


        transform.position = SetWaitingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance2Run)
        {
            waiting = false;
            crawlerAgent.isStopped = false;
            crawlerAgent.SetDestination(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
            crawlerAnim.Play("crawl");

            if (crawlerAgent.pathStatus == NavMeshPathStatus.PathPartial)
            {
                TryToOpenDoor(gameManager.keyCount);
            }
        }
        else
        {
            if (!waiting)
            {
                crawlerAgent.isStopped = false;
                crawlerAgent.SetDestination(SetWaitingPosition());
                crawlerAnim.Play("crawl");
                waiting = true;
            }
            if (crawlerAgent.remainingDistance != Mathf.Infinity && crawlerAgent.pathStatus == NavMeshPathStatus.PathComplete && crawlerAgent.remainingDistance == 0)
            {
                crawlerAgent.isStopped = true;
                crawlerAnim.Play("Idle");
            }
        }
    }

    Vector3 SetWaitingPosition()
    {
        int n = Random.Range(1, 4);

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
