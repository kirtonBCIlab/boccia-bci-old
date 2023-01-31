using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SwitchfromMainCamera : MonoBehaviour
{
    //Bad form - doing this quickly not well
    [SerializeField]
    private GameObject[] displayArray;

    [SerializeField]
    private GameObject mainDisplay;

    [SerializeField]
    private GameObject elevationDisplay;

    [SerializeField]
    private GameObject rotationDisplay;

    //[SerializeField]
    //private GameObject birdsEyeDisplay;

    public Camera mainCamera;
    public Camera elevationCamera;
    public Camera rotationCamera;
    public Camera topCamera;


    //Handle Elevation
    public void ElevationView()
    {
        mainCamera.enabled = false;
        elevationCamera.enabled = true;
    }

        public void SwitchToElevationView()
    {
        if (elevationDisplay == null)
        {
            Debug.Log("No elevation display found - returning with out doing anything. Check your Camera Display Objects!");
            return;
        }

        //Turn off all displays
        displayArray.ToList().ForEach(g => g.SetActive(false));

        //Do the Elevation View
        ElevationView();
        //Set the display active
        elevationDisplay.SetActive(true);

    }






    //Handle Rotation
    public void RotationView()
    {
        rotationCamera.enabled = true;
        topCamera.enabled = true;
        mainCamera.enabled = false;
    }

    public void SwitchToRotationView()
    {
        if (rotationDisplay == null)
        {
            Debug.Log("No rotation display found - returning with out doing anything. Check your Camera Display Objects!");
            return;
        }

        //Turn off all displays
        displayArray.ToList().ForEach(g => g.SetActive(false));

        //Do the Rotation View
        RotationView();
        //Set the display active
        rotationDisplay.SetActive(true);
    }

    public void EnableBirdEyeView()
    {
        topCamera.gameObject.SetActive(true);
    }

    public void DisableBirdEyeView()
    {
        topCamera.gameObject.SetActive(false);
    }



    
    //Return to main
    public void MainScreen()
    {
        mainCamera.enabled = true;
        elevationCamera.enabled = false;
        rotationCamera.enabled = false;
        topCamera.enabled = false;
    }

    public void SwitchToMainDisplay()
    {
        if (mainDisplay == null)
        {
            Debug.Log("No rotation display found - returning with out doing anything. Check your Camera Display Objects!");
            return;
        }

        //Turn off all displays
        displayArray.ToList().ForEach(g => g.SetActive(false));

        //Turn back on Main View
        MainScreen();
        //Set the display active
        mainDisplay.SetActive(true);
    }






    //Change GameObject to Canvas Object - so we can turnOn/Off Canvas.
    public void TurnOffGameObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void TurnOnGameObject(GameObject go)
    {
        go.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            SwitchToElevationView();
        }
    }

}
