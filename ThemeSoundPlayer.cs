using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSoundPlayer : MonoBehaviour
{
    public AudioClip[] ThemeSongs;
    private int clipIndex, lastPlayedIndex = 0;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clipIndex = Random.Range(0, ThemeSongs.Length);
        lastPlayedIndex = clipIndex;
    }
    private void Start()
    {
        audioSource.clip = ThemeSongs[clipIndex];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            clipIndex = Random.Range(0, ThemeSongs.Length);
            if (clipIndex == lastPlayedIndex)
            {
                clipIndex = Random.Range(0, ThemeSongs.Length);
            }
            lastPlayedIndex = clipIndex;
            audioSource.clip = ThemeSongs[clipIndex];
            audioSource.Play();
        }
    }
}
