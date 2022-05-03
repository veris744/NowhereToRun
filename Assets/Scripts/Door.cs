using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private Player playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnPointerEnter()
    {

        if (animator.GetBool("open"))
            playerScript.ShowMessage("Press A to close door");
        else
            playerScript.ShowMessage("Press A to open door");
    }

    private void OnPointerExit()
    {
        playerScript.HideInfoPanel();
    }

    private void OnPointerPressed()
    {
        if (animator.GetBool("open"))
        {
            closeDoor();
            playerScript.ShowMessage("Press A to open door");
        }
        else
        {
            openDoor();
            playerScript.ShowMessage("Press A to close door");
        }

    }

    public void openDoor()
    {
        animator.SetBool("open", true);
    }
    public void closeDoor()
    {
        animator.SetBool("open", false);
    }
}
