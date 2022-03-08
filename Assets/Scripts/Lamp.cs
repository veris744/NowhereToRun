using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject light;
    private Player playerScript;
    public TextMeshProUGUI infoCanvasText;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Main Camera").GetComponent<Player>();
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
        Debug.Log("OnPointerEnter");
    }

    private void OnPointerExit()
    {
        playerScript.HideInfoPanel();
    }
    
    private void OnPointerPressed()
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
