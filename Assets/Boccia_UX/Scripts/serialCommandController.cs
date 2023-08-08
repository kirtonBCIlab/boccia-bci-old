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

    private bool serialEnabled = false; 

    public int COMPort = 6;

    // Start is called before the first frame update
    void Start()
    {

        //ConnectToPort();
        
        rotation_value = Rotation.rotInc;
        rotation_point = rotation_value.ToString();
    
        //incline_point = Incline.currentAngle;    No call for incline in other modules
    
        elevation_value = 1000 * Elevation.heightInc;
        elevation_point = elevation_value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // For general signalling to the serial monitor
    public void ButtonRotationLeft()
    {
        float output = -2000-rotation_value;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
        
    }

    public void ButtonRotationRight()
    {
        float output = 2000+rotation_value;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    }

    public void ButtonElevationUp()
    {
        float output = 3000+elevation_value;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    }

    public void ButtonElevationDown()
    {
        float output = -3000 -  elevation_value;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    
    }

    

     // Reset command for ramp on Unity and prompt to serial monitor for reset
    public void ResetCommand()
    {

        Elevation.ResetHeight();
        Rotation.ResetAngle();
        
        float output = 9700;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}

    }
    


    public void ConnectToPort()
    {
    
        // Get the port we want to connect to from the dropdown
        string port = _ports[COMPort];

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
            serialEnabled = true;
        }
        catch (Exception e)
        {
            // ConnectionText.text = e.Message;
            Debug.Log(e.Message);
            serialEnabled = false;
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