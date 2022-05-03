using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void clickButton()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/Button");
        audioSource.Play();
    }

    public void DoorSqueaks()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/DoorSqueaks");
        audioSource.Play();
    }

    public void Creaking()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/Creaking");
        audioSource.Play();
    }


    public void LookingThroughBush()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/Bush-Shaking");
        audioSource.Play();
    }


    public void Searching()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/Searching");
        audioSource.Play();
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }
}
