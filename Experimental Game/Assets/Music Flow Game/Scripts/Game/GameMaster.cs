using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Scoring")]
    public int playerScore;
    public int aiScore;
    [Space(5)]
    public int winScore;
    public int loseScore;
    [Space(5)]
    public Text playerPoints;
    public Text aiPoints;

    [Header("Paddles Flip")]
    public GameObject paddle1;
    public GameObject paddle2;

    [Space(5)]
    public float moveSpeed;

    Vector3 paddle1StartPos;
    Vector3 paddle2StartPos;



    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;

        paddle1StartPos = paddle1.transform.position;
        paddle2StartPos = paddle2.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            MovePaddles();

        }




        Score();
    }

    void MovePaddles()
    {
        // print("Pressed");

        paddle1.transform.position = Vector3.Lerp(paddle1StartPos, paddle2StartPos, moveSpeed);
        //  paddle2.transform.position = Vector3.Lerp(paddle2StartPos, paddle1StartPos, moveSpeed);

        paddle1.GetComponent<BoxCollider2D>().enabled = false;
        // paddle2.GetComponent<BoxCollider2D>().enabled = false;

    }


    void Score()
    {
        playerPoints.text = playerScore.ToString();
        aiPoints.text = aiScore.ToString();

        if (playerScore >= winScore)
        {
            //win
        }
        else if (aiScore >= loseScore)
        {
            //Lose
        }
    }


}
