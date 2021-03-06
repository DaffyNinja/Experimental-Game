﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballSpeed;

    public GameMaster gMaster;

    public GameObject PlayerPaddle;
    public GameObject EnemyPaddle;

    bool moveToPlayer;

    bool moveToEnemyTop;
    bool moveToEnemyMid;
    bool moveToEnemyBot;


    private Vector2 ballStartPos;

    Rigidbody2D rig;


    // Use this for initialization
    void Start()
    {
        // PlayerPaddle = GameObject.Find("Paddle Player");
        //  EnemyPaddle = GameObject.Find("Paddle CPU");

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
            //this.gameObject.transform.Translate(moveRight);
        }

        if (moveToEnemyMid == true)
        {
            rig.AddForce(new Vector2(-ballSpeed, 0));
            //this.gameObject.transform.Translate(moveLeft);
        }

        //Screen
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);

        if (viewPos.x >= 1f)
        {
            // print("Right");

            gMaster.aiScore++;

            transform.position = ballStartPos;
        }
        else if (viewPos.x <= 0)
        {
            // print("Left");

            gMaster.playerScore++;

            transform.position = ballStartPos;
        }



    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            moveToEnemyMid = false;
            moveToPlayer = false;

            //print("PLAYER");
        }

        if (col.gameObject.name == "Paddle Player 2")
        {
            moveToEnemyMid = false;
            moveToPlayer = false;

        }

        if (col.gameObject.name == "Paddle CPU")
        {
            moveToEnemyMid = false;
            moveToPlayer = false;
        }


    }

}
