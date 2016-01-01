using UnityEngine;
using System.Collections;

public class TopBottomBorders : MonoBehaviour
{

    public bool isTop;
    //public bool isBottom;


    Vector3 worldPoint;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Top
        if (isTop)
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(350, 625, 0));

            gameObject.transform.position = worldPoint;
        }
        else
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(350, 0, 0));

            gameObject.transform.position = worldPoint;
        }



    }
}
