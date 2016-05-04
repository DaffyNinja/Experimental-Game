using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
   // public Canvas mainMenuCanvas;
    public RectTransform creditPanel;

    // Use this for initialization
    void Start()
    {
        creditPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySinleButton()
    {
        SceneManager.LoadScene(1);

    }

    public void Play2Player()
    {
        SceneManager.LoadScene(2);
    }

    public void CreditsButton()
    {
        creditPanel.gameObject.SetActive(true);
      //  mainMenuCanvas.gameObject.SetActive(false);

    }

    public void BackButton()
    {
        creditPanel.gameObject.SetActive(false);
       // mainMenuCanvas.gameObject.SetActive(true);

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
