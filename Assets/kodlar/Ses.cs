using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ses : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip timer;
    public bool isPlaying = false;

    AnaKod anaKod;

    void Awake()
    {
        anaKod = GameObject.Find("Canvas").GetComponent<AnaKod>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (anaKod.zaman <= 9 && isPlaying == false)
        {
            isPlaying = true;
            audioSource.PlayOneShot(timer);
        }
    }


}
