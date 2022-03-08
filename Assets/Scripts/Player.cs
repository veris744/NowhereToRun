using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 4f;
    private float runningSpeed = 8f;

    private Rigidbody rb;
    public GameObject infoCanvas;
    public TextMeshProUGUI infoMessage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f && Mathf.Abs(Input.GetAxis("Vertical")) < 0.1f) {
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
        rb.velocity = s * Input.GetAxis("Horizontal") * transform.right + s * Input.GetAxis("Vertical") * transform.forward;
    }

    public void ShowMessage(string message)
    {
        infoCanvas.SetActive(true);
        infoMessage.text = message;
    }

    public void HideInfoPanel()
    {
        infoMessage.text = "";
        infoCanvas.SetActive(false);
    }
}
