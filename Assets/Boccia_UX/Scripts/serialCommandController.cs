using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;


public class serialCommandController : MonoBehaviour
{
    public AutomatedSelectInstructions Automated;
    public ElevationAdjuster Elevation;
    public InclineAdjustment Incline; 
    public RampRotation Rotation; 
    public TMPro.TMP_Dropdown PortsDropDown;
    private List<string> _ports;
    public Text ConnectionText;
    private SerialPort _serial;
    public string rotation_point;
    public string elevation_point;



    // Start is called before the first frame update
    void Start()
    {

    ConnectToPort();
        
    float rotation_value = Rotation.rotInc;
    string rotation_point = rotation_value.ToString();
    
    //incline_point = Incline.currentAngle;    No call for incline in other modules
    
    float elevation_value = Elevation.heightInc;
    string elevation_point = elevation_value.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.M))
            {

                if (Automated.nextTarget == "ElevationButton")
                {
                    ElevationAdjuster Elevation = ElevationAdjuster();
                    if (Elevation.MoveUp())
                    {
                        _serial.Write("300"+elevation_point);
                        Debug.Log("300"+elevation_point);
                    }
                    else if (Elevation.MoveDown())
                    {
                        _serial.Write("-300"+elevation_point);
                        Debug.Log("300"+elevation_point);
                    }
                }

                
                else if (Automated.nextTarget == "RotationButton")
                {
                   RampRotation Rotation = RampRotation();
                   if (Rotation.RotateLeftS())
                    {
                        _serial.Write("-200"+rotation_point);
                        Debug.Log("-200"+rotation_point);
                    }
                    else if (Rotation.RotateRightS())
                    {
                        _serial.Write("200"+rotation_point);
                        Debug.Log("200"+rotation_point);
                    }
                }
            }
    }
 
    public void ConnectToPort()
    {
        // Get the port we want to connect to from the dropdown
        string port = _ports[PortsDropDown.value];

        try
        {
            // Attempt to create our serial port using 9600 as our baud rate which matches the baud rate we set in the Arduino Sketch we created earlier.
            _serial = new SerialPort(port, 9600)
            {
                Encoding = System.Text.Encoding.UTF8,
                DtrEnable = true
            };

            // Open up our serial connection
            _serial.Open();

            // ConnectionText.text = $"Connected to {port}";
            // Debug.Log(ConnectionText.text);
            Debug.Log("Connected to port: " + port);
        }
        catch (Exception e)
        {
            // ConnectionText.text = e.Message;
            Debug.Log(e.Message);
        }
    }

    public void Disconnect()
    {
        if (_serial != null)
        {
            // Close the connection if it is open
            if (_serial.IsOpen)
            {
                _serial.Close();
            }

            // Release any resources being used
            _serial.Dispose();
            _serial = null;

            if (ConnectionText != null)
            {
                ConnectionText.text = "";
            }
            Debug.Log("Disconnected");
        }
    }

}