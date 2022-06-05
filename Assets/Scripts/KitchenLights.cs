using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenLights : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int r;
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            r = Random.Range(0, 5);

            if (r == 0)
            {
                StartCoroutine(Waiting());
            }
            else if ((r == 1 || r == 2 || r == 3) && !light1.activeSelf)
                TurnOnLights();

        }
    }

    private void TurnOffLights()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        light4.SetActive(false);
        light5.SetActive(false);
        light6.SetActive(false);
        light7.SetActive(false);
        light8.SetActive(false);
    }


    private void TurnOnLights()
    {
        light1.SetActive(true);
        light2.SetActive(true);
        light3.SetActive(true);
        light4.SetActive(true);
        light5.SetActive(true);
        light6.SetActive(true);
        light7.SetActive(true);
        light8.SetActive(true);
    }

    public IEnumerator Waiting()
    {
        TurnOffLights();
        yield return new WaitForSeconds(0.2f);
        TurnOnLights();
        yield return new WaitForSeconds(0.2f);
        
        TurnOffLights();
        yield return new WaitForSeconds(0.2f);
        TurnOnLights();
        yield return new WaitForSeconds(0.2f);

        TurnOffLights();
        yield return new WaitForSeconds(0.2f);
        TurnOnLights();
        yield return new WaitForSeconds(0.2f);

        TurnOffLights();
        yield return new WaitForSeconds(0.2f);
        TurnOnLights();
        yield return new WaitForSeconds(0.2f);

        TurnOffLights();
        yield return new WaitForSeconds(0.2f);
        TurnOnLights();
        yield return new WaitForSeconds(0.2f);

        TurnOffLights();
        yield return new WaitForSeconds(3f);

        int r = Random.Range(0, 2);
        if (r == 0)
        {
            TurnOnLights();
        }

    }
}
