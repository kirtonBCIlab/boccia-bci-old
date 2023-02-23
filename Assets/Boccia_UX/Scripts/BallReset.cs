using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public GameObject ball;
    public GameObject elevationPlate;
    //public GameObject mainShaft;
    private Vector3 originalPos;
    private Vector3 plateOrigPos;
    private Vector3 shaftOrigPos;
    private Vector3 ballDropPos;
    private Quaternion plateOrigRot;
    private Vector3 currentPos;
    private Quaternion initialRotation;
    private Quaternion shaftOrigRot;
    public float maxX = 2f;
    public List <GameObject> ballPit; 
    //public float maxY = 2f;


    // Start is called before the first frame update
    void Start()
    {
        plateOrigPos = elevationPlate.transform.position;
        plateOrigRot = elevationPlate.transform.rotation;
        originalPos = ball.transform.position;
        initialRotation = ball.transform.rotation;  
    }

    // Gets location of plate and ball before when the drop button is pressed
    public void GetBallDropPosition()
    {
        ballDropPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = ball.transform.position;

        //Debug.Log(originalPos + ":" + currentPos);

        // When the ball goes out of frame
        if (currentPos.x >= (originalPos.x + maxX))
        {
            //elevationPlate.transform.position = plateOrigPos;
            //elevationPlate.transform.position = plateOrigPos;
            //ball.transform.position = originalPos;
            //ball.transform.rotation = initialRotation;

            ball.transform.position = ballDropPos;

        }
    }
}
