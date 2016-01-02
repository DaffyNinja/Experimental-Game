using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public bool startMusic;
    [Space(5)]
    public AudioClip song1;
    public AudioClip song2;
    [Space(5)]

    [Header("Volume")]
    [Range(0, 1)]
    public float maxVolume;
    [Range(0, 1)]
    public float minVolume;
    [Space(5)]

    [Header("Time")]
    [Range(0, 1)]
    public float fadeTime;
    [Space(5)]

    [Header("Checks")]
    public bool fadeOut;
    public bool fadeIn;
    public bool startFade;

    [Space(5)]
    public GameMaster gMaster;
    [Space(5)]
    public int changeMusicScore;


    bool playMusic;
    bool playSong2;

    AudioSource aSource;

    // Use this for initialization
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.volume = maxVolume;

        playMusic = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (playMusic == true)
        {
            if (startMusic == true)
            {
                aSource.clip = song1;
                aSource.Play();
                startMusic = false;
            }
        }


        if (gMaster.playerScore >= changeMusicScore || gMaster.aiScore >= changeMusicScore)
        {

            playSong2 = true;

            if (playMusic == true)
            {
                if (playSong2 == true)
                {
                    //print("pLay");

                    startFade = true;

                    if (startFade == true)
                    {

                        //fadeOut = true;

                        if (fadeOut == true)
                        {
                            aSource.volume -= Time.deltaTime * fadeTime;

                            if (aSource.volume <= minVolume)
                            {
                                aSource.clip = song2;
                                aSource.Play();

                                fadeOut = false;
                                fadeIn = true;

                                print("Start Fade in");

                            }
                        }

                        if (fadeIn == true)
                        {
                            aSource.volume += Time.deltaTime * fadeTime;

                            if (aSource.volume >= maxVolume)
                            {
                                fadeIn = false;
                                startFade = false;
                                playSong2 = false;
                                // playMusic = false;
                                //fadeIn = false;
                            }
                        }

                    }
                }

            }
        }


    }
}
