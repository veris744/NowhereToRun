using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject buttonText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    private void OnPointerEnter()
    {
        buttonText.GetComponent<TextMeshProUGUI>().color = new Color(255f / 255f, 27f / 255f, 27f / 255f);
    }

    private void OnPointerExit()
    {
        buttonText.GetComponent<TextMeshProUGUI>().color = new Color(113f / 255f, 27f / 255f, 27f / 255f);
    }

    private void OnPointerPressed()
    {
        gameManager.canvas.SetActive(false);
        gameManager.pause = false;
    }
}
