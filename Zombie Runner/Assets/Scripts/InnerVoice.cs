using UnityEngine;

public class InnerVoice : MonoBehaviour
{
    public AudioClip WhatHappened;
    public AudioClip GoodlandingArea;

    private AudioSource _audioSource;
    // Use this for initialization
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = WhatHappened;
        _audioSource.Play();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnFindClearArea()
    {
        print(name);
        _audioSource.clip = GoodlandingArea;
        _audioSource.Play();

        Invoke("CallHeli", GoodlandingArea.length + 1f);
    }

    private void CallHeli()
    {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}