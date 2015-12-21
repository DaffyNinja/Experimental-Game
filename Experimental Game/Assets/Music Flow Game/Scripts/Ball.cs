using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballSpeed;

    private GameObject PlayerPaddle;
    private GameObject EnemyPaddle;

    private bool moveToPlayer;

    private bool moveToEnemyTop;
    private bool moveToEnemyMid;
    private bool moveToEnemyBot;


    private Vector2 ballStartPos;

    Rigidbody2D rig;


    // Use this for initialization
    void Start()
    {
        PlayerPaddle = GameObject.Find("Paddle Player");

        EnemyPaddle = GameObject.Find("Paddle CPU");

        moveToPlayer = true;

        ballStartPos = this.gameObject.transform.position;

        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveLeft = new Vector2(-ballSpeed, 0);

        Vector2 moveRight = new Vector2(ballSpeed, 0);


        

        if (moveToPlayer == true)
        {
            rig.AddForce(new Vector2(ballSpeed, 0));

           // this.gameObject.transform.Translate(moveRight);
        }

        if (moveToEnemyMid == true)
        {


            this.gameObject.transform.Translate(moveLeft);

        }



    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            moveToEnemyMid = false;

            moveToPlayer = false;

            print("PLAYER");
        }

        if (col.gameObject.name == EnemyPaddle.name)
        {
            moveToEnemyMid = false;

            moveToPlayer = false; ;

            print("enemy");

            //this.gameobject.transform.translate(-ballspeed, 0, 0 * time.deltatime);
        }

        //    if (col.gameObject.name == "Play Top")
        //    {
        //        print("Player Top");

        //        moveToEnemyTop = true;

        //        moveToPlayer = false;
        //    }

        //    if (col.gameObject.name == "Play Mid")
        //    {
        //        moveToPlayer = false;

        //        moveToEnemyTop = false;

        //        moveToEnemyMid = true;

        //        print("PLAYER");

        //        //this.gameObject.transform.Translate(-ballSpeed, 0, 0 * Time.deltaTime);
        //    }



        //    if (col.gameObject.name == "Border Right")
        //    {
        //        this.gameObject.transform.position = ballStartPos;
        //    }

        //    if (col.gameObject.name == "Border Left")
        //    {
        //        this.gameObject.transform.position = ballStartPos;
        //    }
    }

}
