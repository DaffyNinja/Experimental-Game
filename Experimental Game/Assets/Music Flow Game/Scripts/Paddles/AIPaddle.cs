using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour
{

    Vector3 move = Vector3.zero;

    public float speed;

    public Transform ball;
    [Space(5)]
    public AudioClip hitSound;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = hitSound;
    }

    void Update()
    {
        float d = ball.position.y - transform.position.y;

        if (d > 0)
        {
            move.y = speed * Mathf.Min(d, 1.0f);
        }
        if (d < 0)
        {
            move.y = -(speed * Mathf.Min(-d, 1.0f));
        }

        transform.position += move * Time.deltaTime;
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
