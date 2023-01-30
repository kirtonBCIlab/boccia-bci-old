using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class ElevationAdjuster : MonoBehaviour
{
    public GameObject elevatorPlate;
    float targetHeight = 0.0f;
    float currentHeight;
    //float increment = 0.001f;

    public void MoveUp()
    {
        changeHeight(0.001f);
    }

    public void MoveDown()
    {
        changeHeight(-0.001F);
    }

    public void changeHeight(float change)
    {
        targetHeight += change;
        if (targetHeight > 0.0456f)
        {
            targetHeight = 0.0456f;
        }
        else if (targetHeight < 0.0f)
        {
            targetHeight = 0.0f;
        }
        StartCoroutine("ChangeMyHeight", targetHeight);
    }

    public IEnumerator ChangeMyHeight(float target)
    {
        currentHeight = elevatorPlate.transform.position.z;
        //Debug.Log(targetHeight + ":" + currentHeight);
        //float x = 2.0f;
        //if ((currentHeight - targetHeight) < 0.001 & (currentHeight - targetHeight) > -0.001)
        //{
        //    x = 0;
        //}
        if (targetHeight < currentHeight)
        {
            //elevatorPlate.transform.Translate(0, 0, -x * Time.deltaTime);
            elevatorPlate.transform.Translate(Vector3.back * -target);
        }
        else if (targetHeight > currentHeight)
        {
            //elevatorPlate.transform.Translate(0, 0, x * Time.deltaTime);
            elevatorPlate.transform.Translate(Vector3.forward * target);
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
