using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchfromMainCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera inclineCamera;
    public Camera elevationCamera;
    public Camera rotationCamera;
    public Camera topView;

    public void ElevationView() {
        mainCamera.enabled = false;
        elevationCamera.enabled = true;

    }
    public void InclineView() {
        mainCamera.enabled = false;
        inclineCamera.enabled = true;
    }
    public void RotationView()
    {
        rotationCamera.enabled = true;
        topView.enabled = true;
        mainCamera.enabled = false;
    }
    public void BirdEyeView()
    {
        rotationCamera.enabled = true;
        topView.enabled = true;
        mainCamera.enabled = false;
    }
    public void MainScreen() {
        mainCamera.enabled = true;
        elevationCamera.enabled = false;
        inclineCamera.enabled = false;
        rotationCamera.enabled = false;
        topView.enabled = false;
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

    public void DisableCanvas(CanvasGroup co)
    {
        co.GetComponent<CanvasGroup>().enabled = false;
    }

}
