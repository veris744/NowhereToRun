using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject light;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("XRRig").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (light.activeSelf)
        {
            playerScript.ShowMessage("Turn off lamp");

        } else
        {
            playerScript.ShowMessage("Turn on lamp");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerScript.HideInfoPanel();
    }

    private void OnTriggerStay(Collider other)
    {
        if (light.activeSelf)
        {
            playerScript.ShowMessage("Turn off lamp");

        }
        else
        {
            playerScript.ShowMessage("Turn on lamp");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (light.activeSelf)
            {
                light.SetActive(false);

            }
            else
            {
                light.SetActive(true);
            }
        }
    }
}
