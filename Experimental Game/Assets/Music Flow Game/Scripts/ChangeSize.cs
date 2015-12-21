using UnityEngine;
using System.Collections;

public class ChangeSize : MonoBehaviour {

	public float growSize;

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Return))
		{
			transform.localScale = Vector3.Lerp(transform.localScale,new Vector3(0.5f,growSize,0.5f),speed);



		}
	
	}
}
