using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainShaft;
    public float rotInc = 6.0f;
    public float maxRot = 125f;
    public float minRot = 62.5f;
    public float rotSpeed = 10.0f;
    float targetAngle = 90.0f;
    float currentAngle; 

    public void RotateLeftS() {
        changeAngle(-rotInc);
    }
    //public void RotateLeftM() {
    //    changeAngle(-8.0f);
    //    //currentAngle= mainShaft.transform.Rotation.z; 
    //}
    public void RotateRightS() {
        changeAngle(rotInc);
        //currentAngle= mainShaft.transform.rotation.z;  
    }
    //public void RotateRightM() {
    //    changeAngle(8.0f);
    //    //currentAngle= mainShaft.transform.rotation.z;
    //}

    void changeAngle(float change){
        targetAngle += change;
        if (targetAngle>maxRot){
            targetAngle = maxRot;
        } 
        else if (targetAngle < minRot){
            targetAngle = minRot;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = mainShaft.transform.localEulerAngles.y; 
        //Debug.Log(targetAngle + ":" + currentAngle);
        float x = rotSpeed;
        if ((currentAngle-targetAngle) < 0.15 & (currentAngle-targetAngle) > -0.15) {
            x=0;
        }
        else if (targetAngle < currentAngle) {
            mainShaft.transform.Rotate(Vector3.forward, -x * Time.deltaTime);
        }
        else if (targetAngle>currentAngle) {
            mainShaft.transform.Rotate(Vector3.forward, x*Time.deltaTime);
        }
    }
}
