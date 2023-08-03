using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class SerialCommandController : MonoBehaviour
{

    public AutomatedSelectInstructions Automated;
    public ElevationAdjuster Elevation;
    public InclineAdjustment Incline; 
    public RampRotation Rotation; 
    public MainSPO Main;
    public TMPro.TMP_Dropdown PortsDropDown;
    private List<string> _ports;
    public Text ConnectionText;
    private SerialPort _serial;

    public String rotation_point;
    public String elevation_point;

    public float rotation_value;
    public float elevation_value;

    

    // Start is called before the first frame update
    void Start()
    {

        //ConnectToPort();
        
        rotation_value = Rotation.rotInc;
        rotation_point = rotation_value.ToString();
        Debug.Log("Rotation point: " +  rotation_point);
    
        //incline_point = Incline.currentAngle;    No call for incline in other modules
    
        elevation_value = 1000 * Elevation.heightInc;
        elevation_point = elevation_value.ToString();
        Debug.Log("Elevation point: " + elevation_point);
    }

    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.M))
            {
 
                if (Main.myObjectId ==6)
                {
                    _serial.Write("300"+elevation_point);
                    Debug.Log("300"+elevation_point);
                }
                else if (Main.myObjectId==7)
                {
                    _serial.Write("-300"+elevation_point);
                    Debug.Log("300"+elevation_point);
                }
                
                else if (Main.myObjectId ==4)
                {
                    _serial.Write("-200"+rotation_point);
                    Debug.Log("-200"+rotation_point);
                }
                
                else if (Main.myObjectId ==5)
                {
                    _serial.Write("200"+rotation_point);
                    Debug.Log("200"+rotation_point);
                }
            }
    }

    public String RotationCommandOut(int direction)
    {
        // THIS IS AN EXAMPLE, CHANGE THE STRING TO BE THE RIGHT COMMAND FOR THE MCU
        String output = (direction * rotation_value).ToString();
        Debug.Log("Rotation: " + output);

        return output;
    }

    public String ElevationCommandOut(int percentage)
    { 
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