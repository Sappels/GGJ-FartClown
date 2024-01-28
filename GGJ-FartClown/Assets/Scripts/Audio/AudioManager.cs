using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public List<AudioClip> farts = new List<AudioClip>();
    public List<AudioClip> munching = new List<AudioClip>();
    public AudioClip inflate;

    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFartSound()
    {
        int i = Random.Range(0, farts.Count);
        audioSource.PlayOneShot(farts[i], 1f);
    }

    public void PlayInflateSound()
    {
        audioSource.PlayOneShot(inflate, 1f);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, 1f);
    }

    public void PlayEatingSound()
    {
        int i = Random.Range(0, munching.Count);
        Debug.Log("I ate and made a sound " + i);
        audioSource.PlayOneShot(munching[i], 0.5f);
    }

}
