using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySinleButton()
    {
        Application.LoadLevel(1);
    }

    public void Play2Player()
    {
        Application.LoadLevel(2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
