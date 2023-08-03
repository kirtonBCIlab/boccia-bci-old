//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity;
//using static UnityEngine.GraphicsBuffer;

//public class ElevationAdjuster : MonoBehaviour
//{
//    public GameObject elevatorPlate;
//    public float heightInc = 0.005f;
//    public float heightSpeed = 10.0f;
//    float targetHeight = -0.03243253f;
//    float currentHeight;

//    public void MoveUp()
//    {
//        changeHeight(-heightInc);
//    }

//    public void MoveDown()
//    {
//        changeHeight(heightInc);
//    }

//    public void changeHeight(float change)
//    {
//        currentHeight = elevatorPlate.transform.position.z; //new
//        targetHeight = currentHeight += change; //new and old

//        if (targetHeight < -0.05204198f)
//        {
//            targetHeight = -0.05204198f;
//        }
//        if (targetHeight > -0.03243253f)
//        {
//            targetHeight = -0.03243253f;
//        }
//        StartCoroutine("ChangeMyHeight", targetHeight);
//    }

//    public IEnumerator ChangeMyHeight(float target)
//    {
//        currentHeight = elevatorPlate.transform.position.z;

//        float speed = heightSpeed;
//        if ((currentHeight - target) < -0.015 & (currentHeight - target) > 0.015)
//        {
//            speed = 0;
//        }
//        if (target < currentHeight)
//        {
//            elevatorPlate.transform.Translate(Vector3.forward * speed * Time.deltaTime);
//            //elevatorPlate.transform.position.z = currentHeight;
//        }
//        if (target > currentHeight)
//        {
//            elevatorPlate.transform.Translate(Vector3.back * speed * Time.deltaTime);
//        }


//        yield return null;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //currentHeight = elevatorPlate.transform.position.z;
//        Debug.Log(targetHeight + ":" + currentHeight);

//        ////currentHeight = elevatorPlate.transform.position.z;

//        //float speed = heightSpeed;
//        ////if ((currentHeight - targetHeight) < -0.0015 & (currentHeight - targetHeight) > 0.15)
//        ////{
//        ////    speed = 0;
//        ////}
//        //if (targetHeight < currentHeight)
//        //{
//        //    elevatorPlate.transform.Translate(Vector3.forward * Time.deltaTime);
//        //    //elevatorPlate.transform.position.z = currentHeight;
//        //}
//        //if (targetHeight > currentHeight)
//        //{
//        //    elevatorPlate.transform.Translate(Vector3.forward * -Time.deltaTime);
//        //}

//    }

//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using static UnityEngine.GraphicsBuffer;

public class ElevationAdjuster : MonoBehaviour
{
    public GameObject elevatorPlate;
    public float heightInc = 0.0045f;
    public float heightSpeed = 5.0f; //10
    public Vector3 targetHeight;
    //float targetHeight = -0.03243253f;
    public Vector3 currentHeight;
    public Vector3 origHeight;
    public float maxHeight = 0.045f;
    public float minHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetHeight = elevatorPlate.transform.localPosition;
        origHeight = elevatorPlate.transform.localPosition;
    }

    public void MoveUp()
    {
        targetHeight = targetHeight + Vector3.forward * heightInc;
        changeHeight(targetHeight.z);
        //changeHeight(heightInc);
    }

    public void MoveDown()
    {
        targetHeight = targetHeight + Vector3.back * heightInc;
        changeHeight(targetHeight.z);
        //changeHeight(-heightInc);
    }

    public void changeHeight(float change)
    {
        //targetHeight = targetHeight + Vector3.up * heightInc;

        if (targetHeight.z > 0.045f)
        {
            targetHeight.z = 0.045f;
        }
        if (targetHeight.z < 0.0f)
        {
            targetHeight.z = 0.0f;
        }

    }

    public void ResetHeight()
    {
        targetHeight = origHeight;
    }



    // Update is called once per frame
    void Update()
    {
        currentHeight = elevatorPlate.transform.localPosition;
        //Debug.Log(targetHeight + ":" + currentHeight);

        elevatorPlate.transform.localPosition = Vector3.Lerp(currentHeight, targetHeight, heightSpeed * Time.deltaTime);

    }

}
