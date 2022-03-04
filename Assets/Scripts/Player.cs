using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 8f;
    private float runningSpeed = 12f;
    private Vector3 positionPaused;

    private Rigidbody rb;
    public GameObject infoCanvas;
    public TextMeshProUGUI infoMessage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        positionPaused = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f && Mathf.Abs(Input.GetAxis("Vertical")) < 0.1f) {
            transform.position = positionPaused;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.JoystickButton0))
        {
            Move(runningSpeed);
        } else
        {
            Move(speed);
        }
    }

    void Move(float s)
    {
        //transform.Translate(new Vector3(s * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, s * Input.GetAxis("Vertical") * Time.deltaTime), Space.Self);
        rb.MovePosition(transform.position + new Vector3(s * Input.GetAxis("Horizontal"), 0f, s * Input.GetAxis("Vertical")) * Time.deltaTime);
        positionPaused = transform.position;
    }

    public void ShowMessage(string message)
    {
        infoCanvas.SetActive(true);
        infoMessage.text = message;
    }

    public void HideInfoPanel()
    {
        infoCanvas.SetActive(false);
    }
}
