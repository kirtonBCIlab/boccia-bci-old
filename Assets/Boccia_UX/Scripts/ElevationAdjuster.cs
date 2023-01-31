using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class ElevationAdjuster : MonoBehaviour
{
    public GameObject elevatorPlate;
    float targetHeight = -0.03243253f;
    float currentHeight;

    public void MoveUp()
    {
        changeHeight(0.01f);
    }

    public void MoveDown()
    {
        changeHeight(-0.01f);
    }

    public void changeHeight(float change)
    {
        targetHeight += change;
        if (targetHeight > 0.044f)
        {
            targetHeight = 0.044f;
        }
        else if (targetHeight < -0.03243253f)
        {
            targetHeight = -0.03243253f;
        }
        StartCoroutine("ChangeMyHeight", targetHeight);
    }

    public IEnumerator ChangeMyHeight(float target)
    {
        currentHeight = elevatorPlate.transform.position.z;
        //Debug.Log(targetHeight + ":" + currentHeight);
        if ((currentHeight - target) < 0.001)
        {
            target = 0.044f;
        }
        if ((currentHeight - target) > -0.001)
        {

            target = -0.03243253f;
        }

        if (target > currentHeight) //move up
        {
            //elevatorPlate.transform.Translate(0, 0, target);
            elevatorPlate.transform.Translate(Vector3.back * 0.1f); //working to move but it is not stopping at the max
        }

        if (target < currentHeight) //move down
        {
            //elevatorPlate.transform.Translate(0, 0, target);
            elevatorPlate.transform.Translate(Vector3.back * -0.1f); //moving in the wrong direction
        }

        //if ((currentHeight - target) < 0.001)
        //{
        //    target = 0.044f;
        //}
        //if ((currentHeight - target) > -0.001)
        //{

        //    target = -0.03243253f;
        //}

        //if (target > currentHeight) //move up
        //{
        //    //elevatorPlate.transform.Translate(0, 0, target);
        //    elevatorPlate.transform.Translate(Vector3.back * 0.1f); //working to move but it is not stopping at the max
        //}

        //if (target < currentHeight) //move down
        //{
        //    //elevatorPlate.transform.Translate(0, 0, target);
        //    elevatorPlate.transform.Translate(Vector3.back * -0.1f); //moving in the wrong direction
        //}

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
        ////Debug.Log(targetHeight + ":" + currentHeight);
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
