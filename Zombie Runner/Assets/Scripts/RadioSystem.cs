using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour
{

    public AudioClip InitialHeliCall;
    public AudioClip InitialCallReply;

    private AudioSource _audioSource;

	// Use this for initialization
	void Start ()
	{
	    _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMakeInitialHeliCall()
    {
        _audioSource.clip = InitialHeliCall;
        _audioSource.Play();
        Invoke("InitialReply", InitialHeliCall.length + 1);
    }

    private void InitialReply()
    {
        _audioSource.clip = InitialCallReply;
        _audioSource.Play();
        BroadcastMessage("OnDispatchHelicopter");
    }
}
