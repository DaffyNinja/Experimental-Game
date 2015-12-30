using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

	public bool startMusic;
	[Space (5)]
	public AudioClip song1;
	public AudioClip song2;
	[Space (5)]
	public GameMaster gMaster;
	[Space (5)]
	public int changeMusicScore;


	bool playMusic;
	bool playSong2;

	AudioSource aSource;

	// Use this for initialization
	void Start ()
	{
		aSource = GetComponent<AudioSource> ();

//        aSource.clip = song1;
//        aSource.Play();

		playMusic = true;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (playMusic == true) 
		{
			if (startMusic == true) 
			{
				aSource.clip = song1;
				aSource.Play ();
				playMusic = false;
			}
		}

      
		if (gMaster.playerScore >= changeMusicScore || gMaster.aiScore >= changeMusicScore) 
		{
			playSong2 = true;

			if (playSong2 == true) 
			{
				aSource.clip = song2;
				aSource.Play ();
				playSong2 = false;
			}
		}

	
	}
}
