using UnityEngine;
using System.Collections;

// V0.2
public class FlashBackground : MonoBehaviour
{
    public bool canChange;
    [Space(5)]
    public int intesnity;
    public float timeTillChange;
    float timer;
    [Space(5)]
    public Material[] backMaterials;

    int ran;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (canChange == true)
        {
            timer += Time.deltaTime * intesnity;
            if (timer >= timeTillChange)
            {
                ran = Random.Range(0, backMaterials.Length);
                timer = 0;
            }

            RenderSettings.skybox = backMaterials[ran];
        }




    }
}
