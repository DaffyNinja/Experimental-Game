using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyTextInput : MonoBehaviour
{

    public PlayerMove PlayerM;

    public Canvas questionCanvas;

    string inputText;

    // Use this for initialization
    void Start()
    {
        //inputText = GetComponent<InputField>().text;

    }

    // Update is called once per frame
    void Update()
    {
        //print(GetComponent<InputField>().text);

        inputText = GetComponent<InputField>().text;


    }

    public void MyInput()
    {
        print("Done");

        PlayerM.canMove = true;

        questionCanvas.gameObject.SetActive(false);

        print(inputText);

        GetComponent<InputField>().text = null;

        // inputText = GetComponent<InputField>().text;

     

    }
}
