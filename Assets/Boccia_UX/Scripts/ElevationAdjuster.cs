using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class ElevationAdjuster : MonoBehaviour
{
    public GameObject elevatorPlate;
    public float heightInc = 0.005f;
    public float heightSpeed = 10.0f;
    float targetHeight = -0.03243253f;
    float currentHeight;

    public void MoveUp()
    {
        changeHeight(-heightInc);
    }

    public void MoveDown()
    {
        changeHeight(heightInc);
    }

    public void changeHeight(float change)
    {
        targetHeight += change;
        if (targetHeight < -0.05204198f)
        {
            targetHeight = -0.05204198f;
        }
        if (targetHeight > -0.03243253f)
        {
            targetHeight = -0.03243253f;
        }
        StartCoroutine("ChangeMyHeight", targetHeight);
    }

    public IEnumerator ChangeMyHeight(float target)
    {
        currentHeight = elevatorPlate.transform.position.z;

        //if (target < currentHeight) //(target more negative than current) move up
        //{
        //    //elevatorPlate.transform.Translate(0, 0, -target);
        //    //elevatorPlate.transform.Translate(Vector3.forward * 0.1f); //working to move but it is not stopping at the max
        //}

        //else if (target > currentHeight) //(target less negative than current) move down
        //{
        //    //elevatorPlate.transform.Translate(0, 0, target);
        //    //elevatorPlate.transform.Translate(Vector3.back * -0.1f); //moving in the wrong direction
        //}

        float speed = heightSpeed;
        if ((currentHeight - targetHeight) < 0.00015 & (currentHeight - targetHeight) > -0.15)
        {
            speed = 0;
        }
        if (target < currentHeight)
        {
            elevatorPlate.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //elevatorPlate.transform.position.z = currentHeight;
        }
        if (target > currentHeight)
        {
            elevatorPlate.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        yield return null;
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //currentHeight = elevatorPlate.transform.position.z;
        Debug.Log(targetHeight + ":" + currentHeight);
        //float x = 2.0f;
        //if ((currentHeight - targetHeight) < 0.001 & (currentHeight - targetHeight) > -0.001)
        //{
        //    x = 0;
        //}
        //else if (targetHeight < currentHeight)
        //{
        //    //elevatorPlate.transform.Translate(0, 0, -x * Time.deltaTime);
        //    elevatorPlate.transform.Translate(Vector3.back* -x * Time.deltaTime);
        //}
        //else if (targetHeight > currentHeight)
        //{
        //    //elevatorPlate.transform.Translate(0, 0, x * Time.deltaTime);
        //    elevatorPlate.transform.Translate(Vector3.forward* x * Time.deltaTime);
        //}

    }

}
