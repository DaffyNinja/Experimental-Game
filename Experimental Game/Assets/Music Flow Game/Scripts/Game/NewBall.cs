using UnityEngine;
using System.Collections;

public class NewBall : MonoBehaviour
{
    public float speed = 30;

    public GameMaster gMaster;
    [Space(5)]
    public bool canChangeSize;
    public float minSize;
    public float maxSize;
    public float sizeSpeed;
    float newScale;
    float ratio;
    [Space(5)]
    public AudioClip hitPaddlesSound;
    public AudioClip hitWallsSound;
    AudioSource aSource;

    Vector2 ballStartPos;
    Vector2 dir;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        ballStartPos = this.gameObject.transform.position;

        aSource = GetComponent<AudioSource>();

        //ChangeSize
        ratio = Time.deltaTime * sizeSpeed;
        InvokeRepeating("ChangeScale", 1f, 1f);

    }

    void Update()
    {
        //Screen
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);

        // The ball has gone pas the screen on the right adding point to ai score
        if (viewPos.x >= 1f)
        {
            // print("Right");

            if (gMaster.hasFlipped == false)
            {
                gMaster.aiScore++;
            }
            else if (gMaster.hasFlipped == true)
            {
                gMaster.playerScore++;
            }

            dir = new Vector2(-1, 0).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            transform.position = ballStartPos;
        }
        else if (viewPos.x <= 0)   // Add point to player score 
        {
            // print("Left");

            if (gMaster.hasFlipped == false)
            {
                gMaster.playerScore++;
            }
            else if (gMaster.hasFlipped == true)
            {
                gMaster.aiScore++;
            }

            dir = new Vector2(1, 0).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            transform.position = ballStartPos;
        }
    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        // Hit the left Racket?
        if (col.gameObject.name == "Paddle CPU" || col.gameObject.name == "Paddle Player 2")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            //Play Music
            aSource.clip = hitPaddlesSound;
            aSource.Play();
        }

        // Hit the right Racket?
        if (col.gameObject.name == "Paddle Player")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            //Play Music
            aSource.clip = hitPaddlesSound;
            aSource.Play();
        }

        if (col.gameObject.tag == "Wall")
        {
            aSource.clip = hitWallsSound;
            aSource.Play();
        }

    }

    void ChangeSize()
    {

        if (canChangeSize == true)
        {

            float newVal = Mathf.Lerp(transform.localScale.y, newScale, ratio);
            transform.localScale = new Vector3(transform.localScale.x, newVal, transform.localScale.z);
        }
    }
    void ChangeScale()
    {
        newScale = Random.Range(minSize, maxSize);
    }


}