using UnityEngine;
using System.Collections;

public class NewBall : MonoBehaviour
{
    public float speed = 30;

    public GameMaster gMaster;
	[Space(5)]
	public AudioClip hitPaddlesSound;
	public AudioClip hitWallsSound;
	AudioSource aSource;

    Vector2 ballStartPos;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        ballStartPos = this.gameObject.transform.position;

		aSource = GetComponent<AudioSource>();

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
            Vector2 dir = new Vector2(1, y).normalized;

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
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

			//Play Music
			aSource.clip = hitPaddlesSound;
			aSource.Play();
        }

		if(col.gameObject.tag == "Wall")
		{
			aSource.clip = hitWallsSound;
			aSource.Play();
		}

    }
}