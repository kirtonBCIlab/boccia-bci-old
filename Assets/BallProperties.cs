using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProperties : MonoBehaviour
{
    private Rigidbody ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = this.GetComponent<Rigidbody>();
        ball.sleepThreshold = 0.0f;
    }

}
