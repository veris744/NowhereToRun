using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 4f;
    private float runningSpeed = 8f;

    private Animator avatarAnim;
    private Rigidbody rb;
    private GameManager gameManager;
    public GameObject panel;
    public TextMeshProUGUI infoMessage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        avatarAnim = GameObject.Find("Avatar").GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f && Mathf.Abs(Input.GetAxis("Vertical")) < 0.1f || gameManager.pause) {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            avatarAnim.Play("idle");
        }
        else if (Input.GetKey(KeyCode.JoystickButton1))
        {
            Move(runningSpeed);
            avatarAnim.Play("running");
        } else
        {
            Move(speed);
            avatarAnim.Play("walking");
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
}
