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

    private void OnPointerEnter()
    {
        if (light.activeSelf)
        {
            playerScript.ShowMessage("Turn off lamp");

        }
        else
        {
            playerScript.ShowMessage("Turn on lamp");
        }
    }

    private void OnPointerExit()
    {
        playerScript.HideInfoPanel();
    }
    
    private void OnPointerPressed()
    {

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (light.activeSelf)
            {
                light.SetActive(false);
                playerScript.ShowMessage("Turn on lamp");

            }
            else
            {
                light.SetActive(true);
                playerScript.ShowMessage("Turn off lamp");
            }
        }
    }
}
