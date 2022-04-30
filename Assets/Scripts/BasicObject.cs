using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicObject : MonoBehaviour
{
    public bool key;
    private bool looking;

    private Player playerScript;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        looking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnPointerEnter()
    {
        if (gameObject.name.Contains("cardboardBox"))
            playerScript.ShowMessage("Press A to look inside");
        else
            playerScript.ShowMessage("Press A to look around");
    }

    private void OnPointerExit()
    {
        if (looking)
            StopCoroutine(Looking());
        
        playerScript.HideInfoPanel();
    }

    private void OnPointerPressed()
    {
        StartCoroutine(Looking());
    }


    public IEnumerator Looking()
    {
        looking = true;
        playerScript.ShowMessage("Looking...");

        yield return new WaitForSeconds(5);

        if (key)
        {
            playerScript.ShowMessage("You found a key!");
            if (gameObject.name.Contains("cardboardBox"))
                gameManager.key1 = true;
            else if (gameObject.name.Contains("Bush"))
                gameManager.key2 = true;
            else
                gameManager.key3 = true;

            key = false;
            gameManager.keyCount += 1;

        }
        else
            playerScript.ShowMessage("You found nothing");

        yield return new WaitForSeconds(5);
        playerScript.HideInfoPanel();

        looking = false;
    }

}
