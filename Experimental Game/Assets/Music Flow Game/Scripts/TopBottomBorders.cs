using UnityEngine;
using System.Collections;

public class TopBottomBorders : MonoBehaviour
{



    public bool isTop;
    [Space(5)]
    public float ySize;
   // public float zSize;


    //public bool isBottom;

    Camera mainCam;
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
            transform.localScale = new Vector3(newScale, ySize, 1);

        }
        else
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(350, 0, mainCam.nearClipPlane));

            gameObject.transform.position = worldPoint;

            // Scale
            int newScale = mainCam.pixelWidth;
            transform.localScale = new Vector3(newScale, ySize, 1);

        }



    }
}
