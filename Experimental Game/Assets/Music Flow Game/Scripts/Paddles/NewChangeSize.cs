using UnityEngine;
using System.Collections;

//V0.1

public class NewChangeSize : MonoBehaviour
{
    public bool changeSize;

    public float minSize;
    public float maxSize;

    public float speed;

    public float rotateSpeed;
    [Header("Padddles Start Position")]
    public bool isRightPaddle;
    public float xLength;
    public float yLength;
    [Space(5)]
    public GameMaster gMaster;
    // public bool isLeftPaddle;

    Camera mainCam;
    Vector3 worldPoint;
    Vector3 zoomedOutPoint;

    float newScale;
    float ratio;
    bool canChange = true;

    void Start()
    {
        ratio = Time.deltaTime * speed;
        InvokeRepeating("ChangeScale", 1f, 1f);

        mainCam = Camera.main;

        if (isRightPaddle)
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth + xLength, yLength, 10));
            gameObject.transform.position = worldPoint;
        }
        else
        {
            worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(xLength, yLength, 10));
            gameObject.transform.position = worldPoint;

        }

    }

    void Update()
    {
        if (changeSize == true)
        {
            float newVal = Mathf.Lerp(transform.localScale.y, newScale, ratio);
            transform.localScale = new Vector3(transform.localScale.x, newVal, transform.localScale.z);
        }
        // Rotate

        transform.Rotate(0, 0, rotateSpeed, 0);


        if (canChange == true)
        {

            if (gMaster.hasZoomed == true)
            {
                if (isRightPaddle)
                {
                    worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth + xLength, yLength, 10));
                    gameObject.transform.position = worldPoint;
                }
                else
                {
                    worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(xLength, yLength, 10));
                    gameObject.transform.position = worldPoint;

                }

                canChange = false;
            }
        }


    }
    void ChangeScale()
    {
        newScale = Random.Range(minSize, maxSize);
    }
}