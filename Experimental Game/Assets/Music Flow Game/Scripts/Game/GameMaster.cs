using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Scoring")]
    public int playerScore;
    public int aiScore;
    [Space(5)]
    public bool canChange;
    public int changeBackgroundScore;
    public int changeMusicScore;
    public int changeSizeScore;
    public int rotatePaddlesScore;
    //public int flipPositionsScore;
    public int cameraZoomOutScore;
    [Space(5)]
    public int winScore;
    public int loseScore;
    [Space(5)]
    public Text playerPointsText;
    public Text aiPointsText;

    [Space(5)]
    [Header("Rotate Paddles")]
    public float rotateSpeed;
    public float changeRotateTime;

    bool rotateLeft;
    bool rotateRight;

    float rotateTimer;

    [Header("Paddles Flip")]
    public GameObject paddle1;
    public GameObject paddle2;

    [Space(5)]
    public float moveSpeed;
    [Space(5)]
    public MusicManager musMan;

    FlashBackground flashBack;

    Vector3 paddle1StartPos;
    Vector3 paddle2StartPos;

    bool canFlip;
    bool canMove;
    public bool hasFlipped;

    [Space(5)]
    [Header("Camera")]
    public float zoomOutSize;
    public float zoomSpeed;
    public bool hasZoomed;



    Camera mainCam;



    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;

        mainCam = Camera.main;

        flashBack = GetComponent<FlashBackground>();

        paddle1StartPos = paddle1.transform.position;
        paddle2StartPos = paddle2.transform.position;

        rotateRight = true;

        canFlip = true;



    }

    // Update is called once per frame
    void Update()
    {





        if (canChange)
        {
            Score();
        }

        Controls();

    }


    void Score()
    {
        playerPointsText.text = playerScore.ToString();
        aiPointsText.text = aiScore.ToString();

        // Background Change
        if (playerScore >= changeBackgroundScore || aiScore >= changeBackgroundScore)
        {
            flashBack.canChange = true;
        }

        // Change paddle sizes  & change music
        if (playerScore >= changeSizeScore || aiScore >= changeSizeScore)
        {
            paddle1.GetComponent<NewChangeSize>().changeSize = true;
            paddle2.GetComponent<NewChangeSize>().changeSize = true;


        }

        // Music

        if (playerScore >= changeMusicScore || aiScore >= changeMusicScore)
        {
            musMan.playSong2 = true;
        }

        if (playerScore >= rotatePaddlesScore || aiScore >= rotatePaddlesScore)
        {

            if (rotateRight == true)
            {
                paddle1.transform.Rotate(0, 0, rotateSpeed, 0);
                paddle2.transform.Rotate(0, 0, rotateSpeed, 0);

                rotateTimer += Time.deltaTime;

                if (rotateTimer >= changeRotateTime)
                {
                    rotateRight = false;
                    rotateTimer = 0;
                }
            }
            else if (rotateRight == false)
            {
                paddle1.transform.Rotate(0, 0, -rotateSpeed, 0);
                paddle2.transform.Rotate(0, 0, -rotateSpeed, 0);

                rotateTimer += Time.deltaTime;

                if (rotateTimer >= changeRotateTime)
                {
                    rotateRight = true;
                    rotateTimer = 0;
                }
            }

            // Change direction
        }

        // Flip
        //if (playerScore >= flipPositionsScore || aiScore >= flipPositionsScore)
        //{
        //    print("Flip");
        //    canMove = true;
        //    canFlip = false;
        //    hasFlipped = true;
        //}

        // Camera zoom out
        if (playerScore >= cameraZoomOutScore || aiScore >= cameraZoomOutScore)
        {
            mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, zoomOutSize, zoomSpeed * Time.deltaTime);
        }

        if (mainCam.orthographicSize >= zoomOutSize - 0.1f)
        {
            //print("I have zoomed out");
            hasZoomed = true;
        }

        // Win Lose
        if (playerScore >= winScore)
        {
            //win
            Application.LoadLevel(0);
        }
        else if (aiScore >= loseScore)
        {
            //Lose
            Application.LoadLevel(0);
        }
    }


    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit

            // print("Quit");

            Application.LoadLevel(0);


        }
    }


}
