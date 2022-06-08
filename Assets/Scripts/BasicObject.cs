using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicObject : MonoBehaviour
{
    public bool key;

    private Player playerScript;
    private GameManager gameManager;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
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
        StopCoroutine(Looking());
        audioManager.StopPlaying();
        playerScript.HideInfoPanel();
    }

    private void OnPointerPressed()
    {
        StartCoroutine(Looking());
    }


    public IEnumerator Looking()
    {
        playerScript.ShowMessage("Looking...");

        if (gameObject.name.Contains("Bush"))
            audioManager.LookingThroughBush();
        else
            audioManager.Searching();

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

            gameManager.KeyFound();

            audioManager.StopPlaying();
        }
        else
        {
            playerScript.ShowMessage("You found nothing");
            audioManager.StopPlaying();
        }
            

    }

}
