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



    float newScale;
    float ratio;

    void Start()
    {
        ratio = Time.deltaTime * speed;
        InvokeRepeating("ChangeScale", 1f, 1f);
    }

    void Update()
    {
        if (changeSize == transform)
        {

            float newVal = Mathf.Lerp(transform.localScale.y, newScale, ratio);
            transform.localScale = new Vector3(transform.localScale.x, newVal, transform.localScale.z);
        }
        // Rotate

        transform.Rotate(0, 0, rotateSpeed, 0);


    }
    void ChangeScale()
    {
        newScale = Random.Range(minSize, maxSize);
    }
}