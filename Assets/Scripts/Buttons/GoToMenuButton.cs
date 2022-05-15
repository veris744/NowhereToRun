using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuButton : MonoBehaviour
{
    public GameObject buttonText;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
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
        audioManager.clickButton();
        StartCoroutine(Loading());
    }

    public IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuScene");
    }
}
