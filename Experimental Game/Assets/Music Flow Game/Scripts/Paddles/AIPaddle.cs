using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour {

    public float speed;


    GameObject ballOBJ;


    Rigidbody2D rig;

	// Use this for initialization
	void Start () 
    {
        ballOBJ = GameObject.FindGameObjectWithTag("Ball");

        rig = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.Translate(0, ballOBJ.transform.position.y * Time.deltaTime * speed, 0);

        rig.velocity = new Vector2(rig.velocity.x, ballOBJ.transform.position.y * speed);
	
	}
}
