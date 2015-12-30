using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Scoring")]
    public int playerScore;
    public int aiScore;
    [Space(5)]
    public int flipPositionsScore;
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

    bool canFlip;
    bool canMove;
    public bool hasFlipped;



    // Use this for initialization
    void Start()
    {
       // Cursor.visible = false;

        paddle1StartPos = paddle1.transform.position;
        paddle2StartPos = paddle2.transform.position;

        canFlip = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canFlip == true)
        {
            if (playerScore >= flipPositionsScore || aiScore >= flipPositionsScore)
            {
                print("Flip");
                canMove = true;
                canFlip = false;
                hasFlipped = true;
            }
        }

        if (canMove)
        {
            MovePaddles();
        }



        Score();
    }

    void MovePaddles()
    {
        // print("Pressed");
        paddle1.transform.position = Vector3.Lerp(paddle1StartPos, paddle2StartPos, moveSpeed);
        paddle2.transform.position = Vector3.Lerp(paddle2StartPos, paddle1StartPos, moveSpeed);

        if (paddle1.transform.position == paddle2StartPos)
        {
            //print("Done");

            canMove = false;
        }

    }


    void Score()
    {
        playerPoints.text = playerScore.ToString();
        aiPoints.text = aiScore.ToString();

        if (playerScore >= winScore)
        {
            //win
			Application.LoadLevel(0);
        }
        else if (aiScore >= loseScore)
        {
            //Lose
        }
    }


}
