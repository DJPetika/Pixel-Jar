using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct SFXEvent
{
    public string EventName;
    public AudioClip Sound;
}

public class SFXManager : MonoBehaviour
{
    private AudioSource AudioSource;
    public SFXEvent[] SFXEvents;

    public 

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = this.GetComponent<AudioSource>();

        foreach(SFXEvent sFXEvent in SFXEvents)
        {
            GameManager.instance.StartListening(sFXEvent.EventName, delegate { AudioSource.PlayOneShot(sFXEvent.Sound); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
