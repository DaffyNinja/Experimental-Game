using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeelingTrig : MonoBehaviour
{

    public Canvas questionCanvas;

    public PlayerMove playerM;

    [Space(5)]

    public TextMesh tMesh;

  //  public string trigText;

    // Use this for initialization
    void Start()
    {
        questionCanvas.gameObject.SetActive(false);

        tMesh = GetComponentInChildren<TextMesh>();

      //  tMesh.text = trigText;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // print("Hit");

        questionCanvas.gameObject.SetActive(true);

        playerM.canMove = false;
    }


}
