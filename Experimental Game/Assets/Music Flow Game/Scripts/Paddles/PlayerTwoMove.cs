﻿using UnityEngine;
using System.Collections;

public class PlayerTwoMove : MonoBehaviour {

    public float speed;

   // Rigidbody2D rig2D;

    // Use this for initialization
    void Start()
    {
      //  rig2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.fixedDeltaTime, 0);
            // rig2D.velocity = new Vector2(rig2D.velocity.x, Input.GetAxis("Vertical") * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.fixedDeltaTime, 0);
            //rig2D.velocity = new Vector2(rig2D.velocity.x, -Input.GetAxis("Vertical") * -speed);
        }

    }
}