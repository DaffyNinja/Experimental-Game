using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour {

    public float speed;


    GameObject ballOBJ;

	// Use this for initialization
	void Start () 
    {
        ballOBJ = GameObject.FindGameObjectWithTag("Ball");
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(0, ballOBJ.transform.position.y * Time.deltaTime * speed, 0);
	
	}
}
