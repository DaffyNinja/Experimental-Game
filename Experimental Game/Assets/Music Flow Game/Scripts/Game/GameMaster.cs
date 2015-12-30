using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Scoring")]
    public int playerScore;
    public int aiScore;
    [Space(5)]
	public int changeBackgroundScore;
	public int changeSizeScore;
    public int flipPositionsScore;
    [Space(5)]
    public int winScore;
    public int loseScore;
    [Space(5)]
    public Text playerPointsText;
    public Text aiPointsText;

    [Header("Paddles Flip")]
    public GameObject paddle1;
    public GameObject paddle2;

    [Space(5)]
    public float moveSpeed;

	FlashBackground flashBack;

    Vector3 paddle1StartPos;
    Vector3 paddle2StartPos;

    bool canFlip;
    bool canMove;
    public bool hasFlipped;



    // Use this for initialization
    void Start()
    {
       // Cursor.visible = false;

		flashBack = GetComponent<FlashBackground>();

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
		playerPointsText.text = playerScore.ToString();
		aiPointsText.text = aiScore.ToString();

		if(playerScore >= changeBackgroundScore || aiScore >= changeBackgroundScore)
		{
			flashBack.canChange = true;
		}

		if(playerScore >= changeSizeScore || aiScore >= changeSizeScore)
		{
			paddle1.GetComponent<NewChangeSize>().changeSize = true;
			paddle2.GetComponent<NewChangeSize>().changeSize = true;
		}
			

        if (playerScore >= winScore)
        {
            //win
			//Application.LoadLevel(0);
        }
        else if (aiScore >= loseScore)
        {
            //Lose
        }
    }


}
