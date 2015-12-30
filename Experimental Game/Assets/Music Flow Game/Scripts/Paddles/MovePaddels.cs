using UnityEngine;
using System.Collections;

public class MovePaddels : MonoBehaviour
{

    public float speed;
    [Space(5)]
    public AudioClip hitSound;
    AudioSource aSource;


    Rigidbody2D rig2D;

    // Use this for initialization
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();

        aSource.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // transform.Translate(0, speed * Time.fixedDeltaTime, 0);
            rig2D.velocity = new Vector2(rig2D.velocity.x, Input.GetAxis("Vertical") * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(0, -speed * Time.fixedDeltaTime, 0);
            rig2D.velocity = new Vector2(rig2D.velocity.x, -Input.GetAxis("Vertical") * -speed);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            //print("Hit");
            aSource.Play();
        }
    }
}
