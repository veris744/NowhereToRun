using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private Player playerScript;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnPointerEnter()
    {
        playerScript.ShowMessage("Press A to open door");
    }

    private void OnPointerExit()
    {
        playerScript.HideInfoPanel();
    }

    private void OnPointerPressed()
    {
        if (gameManager.key1 & gameManager.key2 & gameManager.key3)
        {
            gameManager.Winning();
            playerScript.HideInfoPanel();
        }
        else
        {
            playerScript.ShowMessage("Door locked");
        }
    }

}
