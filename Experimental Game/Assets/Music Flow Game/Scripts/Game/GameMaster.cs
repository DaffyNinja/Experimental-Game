using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int playerScore;
    public int aiScore;

    [Space(5)]

    public int winScore;

    public int loseScore;

    [Space(5)]

    public Text playerPoints;
    public Text aiPoints;



	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        playerPoints.text = playerScore.ToString();

        aiPoints.text = aiScore.ToString();

        if (playerScore >= winScore)
        {
            //win
        }
        else if (aiScore >= loseScore)
        {
            //Lose
        }
	
	}
}
