using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public GameObject ball;
    public GameObject elevationPlate;
    public Vector3 originalPos;
    public Vector3 plateOrigPos;
    public Quaternion plateOrigRot;
    private Vector3 currentPos;
    public Quaternion initialRotation;
    public float maxX = 2f;
    //public float maxY = 2f;


    // Start is called before the first frame update
    void Start()
    {
        plateOrigPos = elevationPlate.transform.position;
        plateOrigRot = elevationPlate.transform.rotation;
        originalPos = ball.transform.position;
        initialRotation = ball.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = ball.transform.position;
        Debug.Log(originalPos + ":" + currentPos);
        if (ball.transform.position.x >= maxX)
        {
            elevationPlate.transform.position = plateOrigPos;
            elevationPlate.transform.position = plateOrigPos;
            ball.transform.position = originalPos;
            ball.transform.rotation = initialRotation;

        }
    }
}
