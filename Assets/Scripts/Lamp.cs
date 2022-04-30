using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool counter;

    public GameObject light;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        counter = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPointerEnter()
    {
        if (light.activeSelf)
        {
            playerScript.ShowMessage("Press A to turn off lamp");

        }
        else
        {
            playerScript.ShowMessage("Press A to turn on lamp");
        }
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
            playerScript.ShowMessage("Press A to turn on lamp");
            if (counter)
            {
                StopCoroutine(Waiting());
                counter = false;
                if (playerScript.panel.activeSelf)
                    playerScript.ShowMessage("Press A to turn on lamp");
            }

        }
        else
        {
            light.SetActive(true);
            playerScript.ShowMessage("Press A to turn off lamp");
            StartCoroutine(Waiting());
        }
    }

    public IEnumerator Waiting()
    {
        counter = true;
        yield return new WaitForSeconds(15);
        light.SetActive(false);
    }
}
