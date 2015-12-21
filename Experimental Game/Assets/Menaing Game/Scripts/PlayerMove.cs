using UnityEngine;
using System.Collections;

// V0.1
// Moves similar to the old Zelda games

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;

    public bool canMove;

    Rigidbody2D rig2D;


    // Use this for initialization
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rig2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rig2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rig2D.velocity = new Vector2(-Input.GetAxis("Horizontal") * -moveSpeed, rig2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rig2D.velocity = new Vector2(rig2D.velocity.x, Input.GetAxis("Vertical") * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rig2D.velocity = new Vector2(rig2D.velocity.x, -Input.GetAxis("Vertical") * -moveSpeed);
        }
    }
}
