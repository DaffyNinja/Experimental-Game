using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip song1;
    public AudioClip song2;
    [Space(5)]
    public GameMaster gMaster;
    [Space(5)]
    public int changeMusicScore;


    bool playMusic;

    AudioSource aSource;

	// Use this for initialization
	void Start () 
    {
        aSource = GetComponent<AudioSource>();

        aSource.clip = song1;
        aSource.Play();

        playMusic = true;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (playMusic == true)
        {
            if (gMaster.playerScore >= changeMusicScore)
            {
                aSource.clip = song2;
                aSource.Play();
                playMusic = false;
            }
        }

	
	}
}
