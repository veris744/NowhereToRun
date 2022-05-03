using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool pause;
    public bool finished;
    public bool key1;
    public bool key2;
    public bool key3;
    public int keyCount;

    private int nHideoutsKey1 = 14;
    private int nHideoutsKey2 = 13;
    private int nHideoutsKey3 = 20;

    public List<string> monsters;

    public GameObject canvas;
    public GameObject playButton;
    public GameObject goToMenuButton;
    public GameObject resumeButton;
    public TextMeshProUGUI text;
    private TextMeshProUGUI keyCounter;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        finished = false;
        player = GameObject.Find("Player");
        keyCounter = GameObject.Find("KeysCounter").GetComponent<TextMeshProUGUI>();
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            SpawnKeys();

            monsters.Add("Ghoul1");
            monsters.Add("Ghoul2");
            monsters.Add("Ghoul3");
            monsters.Add("Crawler1");
            monsters.Add("Crawler2");

            SpawnMonster();
            SpawnMonster();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Joystick1Button7)||Input.GetKeyUp(KeyCode.Escape) && !finished 
            && SceneManager.GetActiveScene().name == "GameScene")
        {
            if (canvas.activeSelf)
            {
                canvas.SetActive(false);
                pause = false;
            } else
            {
                canvas.GetComponent<RectTransform>().localPosition = player.transform.position + player.transform.forward * 1;
                canvas.GetComponent<RectTransform>().localRotation = player.transform.localRotation;
                canvas.SetActive(true);
                playButton.SetActive(false);
                resumeButton.SetActive(true);
                goToMenuButton.SetActive(true);
                text.text = "PAUSED";
                pause = true;
            }
        }


        keyCounter.text = keyCount + "/3";
    }

    public void KeyFound()
    {
        keyCount += 1;
        SpawnMonster();
    }

    void SpawnKeys()
    {
        key1 = false;
        key2 = false;
        key3 = false;
        keyCount = 0;

        int randomInt = Random.Range(1, nHideoutsKey1);
        GameObject.Find("cardboardBox " + randomInt).GetComponent<BasicObject>().key = true;


        randomInt = Random.Range(1, nHideoutsKey2);
        GameObject.Find("Bush " + randomInt).GetComponent<BasicObject>().key = true;

        randomInt = Random.Range(1, nHideoutsKey3);
        GameObject.Find("Hideout " + randomInt).GetComponent<BasicObject>().key = true;
    }

    public void Winning()
    {
        canvas.GetComponent<RectTransform>().localPosition = player.transform.position + player.transform.forward * 1;
        canvas.GetComponent<RectTransform>().localRotation = player.transform.localRotation;
        text.text = "YOU SURVIVED";
        canvas.SetActive(true);
        playButton.SetActive(true);
        resumeButton.SetActive(false);
        goToMenuButton.SetActive(true);
        pause = true;
        finished = true;
    }

    public void GameOver()
    {
        canvas.GetComponent<RectTransform>().localPosition = player.transform.position + player.transform.forward * 1;
        canvas.GetComponent<RectTransform>().localRotation = player.transform.localRotation;
        text.text = "GAME OVER";
        canvas.SetActive(true);
        playButton.SetActive(true);
        resumeButton.SetActive(false);
        goToMenuButton.SetActive(true);
        pause = true;
        finished = true;
    }

    private void SpawnMonster()
    {
        string monster = monsters[Random.Range(0, monsters.Count - 1)];
        monsters.Remove(monster);
        GameObject.Instantiate(Resources.Load(monster), new Vector3(0, -100, 0), Quaternion.identity, GameObject.Find("NavMesh").transform);
    }
}
