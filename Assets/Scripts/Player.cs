using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 4f;
    private float runningSpeed = 8f;

    private bool playingRunAudio;
    private bool playingWalkAudio;

    private Animator avatarAnim;
    private Rigidbody rb;
    private AudioSource audioSource;
    private GameManager gameManager;
    private AudioManager audioManager;
    public GameObject panel;
    public TextMeshProUGUI infoMessage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        avatarAnim = GameObject.Find("Avatar").GetComponent<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
        playingRunAudio = false;
        playingWalkAudio = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f && Mathf.Abs(Input.GetAxis("Vertical")) < 0.1f || gameManager.pause) {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            avatarAnim.Play("idle");
            audioSource.Stop();
            playingRunAudio = false;
            playingWalkAudio = false;
        }
        else if (Input.GetKey(KeyCode.JoystickButton1))
        {
            Move(runningSpeed);
            avatarAnim.Play("running");
            if (!playingRunAudio)
            {
                playingRunAudio = true;
                playingWalkAudio = false;
                PlayAudio("Audio/Footsteps_Run");
            }
        } else
        {
            Move(speed);
            avatarAnim.Play("walking");
            if (!playingWalkAudio)
            {
                playingRunAudio = false;
                playingWalkAudio = true;
                PlayAudio("Audio/Footsteps_Walk");
            }
        }
    }

    void Move(float s)
    {
        rb.velocity = s * Input.GetAxis("Horizontal") * transform.right + s * Input.GetAxis("Vertical") * transform.forward;
    }

    public void ShowMessage(string message)
    {
        panel.SetActive(true);
        infoMessage.text = message;
    }

    public void HideInfoPanel()
    {
        infoMessage.text = "";
        panel.SetActive(false);
    }

    private void PlayAudio(string audio)
    {
        audioSource.clip = Resources.Load<AudioClip>(audio);
        audioSource.Play();
    }



    private void OnTriggerEnter(Collider other)
    {
        int r;
        if (other.tag == "NPC")
        {
            gameManager.GameOver();
        }
        else if (other.tag == "Creaking")
        {
            audioManager.Creaking();
        }
        else if (other.name == "Painting")
        {
            r = Random.Range(0, 3);
            if (r == 0)
                audioManager.MovePainting();
        }
    }
}
