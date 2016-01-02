using UnityEngine;
using System.Collections;

public class TopBottomBorders : MonoBehaviour
{

    public Camera mainCam;

    public bool isTop;
    //public bool isBottom;


    Vector3 worldPoint;


    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        // Top
        if (isTop)
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, mainCam.pixelHeight, mainCam.nearClipPlane));

            gameObject.transform.position = worldPoint;


            // Scale
            int newScale = mainCam.pixelWidth;
            transform.localScale = new Vector3(newScale, 1, 1);

        }
        else
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(350, 0, mainCam.nearClipPlane));

            gameObject.transform.position = worldPoint;

            // Scale
            int newScale = mainCam.pixelWidth;
            transform.localScale = new Vector3(newScale, 1, 1);

        }



    }
}
