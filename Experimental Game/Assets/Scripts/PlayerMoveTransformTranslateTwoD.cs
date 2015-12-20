using UnityEngine;
using System.Collections;

// V 0.3
// 2D
//Description: Siilar to 80s Zelda game movement


public class PlayerMoveTransformTranslateTwoD : MonoBehaviour
{
    public float hozSpeed;

    public float verSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();


    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(hozSpeed * Time.fixedDeltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-hozSpeed * Time.fixedDeltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, verSpeed * Time.fixedDeltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -verSpeed * Time.fixedDeltaTime, 0);
        }
    }
}
