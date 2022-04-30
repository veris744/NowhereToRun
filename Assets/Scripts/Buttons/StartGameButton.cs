using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public GameObject buttonText;

    void Start()
    {

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
        SceneManager.LoadScene("GameScene");
    }
}
