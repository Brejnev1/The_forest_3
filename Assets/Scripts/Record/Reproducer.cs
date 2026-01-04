using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reproducer : MonoBehaviour
{
    [SerializeField] private TextMeshPro nameSong;
    [SerializeField] private TextMeshPro timeSong;
    private AudioSource audioSource;
    public AudioClip[] musics;
    public int Rand;
    public int Index;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PreviousSong()
    {
        Index--;
        if (Index < 0)
        { 
            Index = 0;
        }
        AudioSoursePlay();
    }

    public void NextSong()
    {
        Index++;
        if (Index > musics.Length - 1)
        {
            Index = musics.Length - 1;
        }
        AudioSoursePlay();
    }

    public void PlayAudio()
    {
        if (audioSource.clip != null) 
        {
            audioSource.Play();
        }
        else
        {
            Index = 0;
            AudioSoursePlay();
        }
    }

    private void AudioSoursePlay()
    {
        nameSong.text = audioSource.clip.nameSong;
        audioSource.clip = musics[Index];
        audioSource.Play();
    } 
}
