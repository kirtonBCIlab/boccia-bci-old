using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationAdjuster : MonoBehaviour
{
    public GameObject elevation;
    float targetHeight;
    float currentHeight;

    public void MoveUp()
    {
        changeHeight(2.0f);
    }

    public void MoveDown()
    {
        changeHeight(-2.0f);
    }

    void changeHeight(float change)
    {
        targetHeight += change;
        if (targetHeight > 180f) //change this number
        {
            targetHeight = 180f; //change this number
        }
        else if (targetHeight < 0.0f) //change this number
        {
            targetHeight = 0.0f; //change this number
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHeight = elevation.transform.localEulerAngles.y;
        Debug.Log(targetHeight + ":" + currentHeight);
        float x = 10.0f;
        if ((currentHeight - targetHeight) < 0.15 & (currentHeight - targetHeight) > -0.15)
        {
            x = 0;
        }
        else if (targetHeight < currentHeight)
        {
            elevation.transform.Rotate(Vector3.forward, -x * Time.deltaTime);
        }
        else if (targetHeight > currentHeight)
        {
            elevation.transform.Rotate(Vector3.forward, x * Time.deltaTime);
        }

    }
}
