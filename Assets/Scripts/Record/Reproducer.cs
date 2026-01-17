using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reproducer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI nameSong;
	[SerializeField] private TextMeshProUGUI creator;

	[SerializeField] private Slider timeSong;

	private AudioSource audioSource;
	public AudioClip[] musics;

	public int Rand;
	public int Index;

	private bool isPlaying;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		isPlaying = false;
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
		if (audioSource.clip != null && isPlaying == false)
		{
			audioSource.Play();
			isPlaying = true;
		}
		else if (isPlaying == true)
		{
			audioSource.Pause();
			isPlaying = false;
		}
		else
		{
			Index = 0;
			AudioSoursePlay();
		}
	}

	private void Update()
	{
		if (isPlaying == true)
		{
			timeSong.value += Time.deltaTime;
		}
		if (timeSong.value == timeSong.maxValue)
		{
			NextSong();
		}
	}

	private void AudioSoursePlay()
	{
		isPlaying = true;
		
		audioSource.clip = musics[Index];
		audioSource.Play();
		
		string[] informationSong = audioSource.clip.name.Split('-');
		nameSong.text = informationSong[1];
		creator.text = informationSong[0];
		
		timeSong.maxValue = audioSource.clip.length;
		timeSong.value = 0;
	} 
}
