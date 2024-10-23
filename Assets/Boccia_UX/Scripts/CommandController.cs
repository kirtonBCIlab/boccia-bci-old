using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class CommandController : MonoBehaviour
{
 
    public ElevationAdjuster Elevation;
    public InclineAdjustment Incline; 
    public RampRotation Rotation; 
    private List<string> _ports;
    private SerialPort _serial;

    [SerializeField]
    private string output_calibration;

    [SerializeField]
    private string output_reset;

    private bool serialEnabled = false; 

    public String COMPort = "COM7"; 

    // Start is called before the first frame update
    void Start()
    {
        // output_calibration = "da100>ec1";
        // output_reset = "ea50";           
    }

    // Update is called once per frame
    void Update()
    {
        if (serialEnabled)
        {
            if (_serial.IsOpen && _serial.BytesToRead > 0)
            {
                string data = _serial.ReadLine();
                Debug.Log(data);
            }
    
        }
    }

    // For general signalling to the serial monitor
    public void ButtonRotationLeft()
    {
        if (serialEnabled){_serial.Write("rr" + -1*Rotation.rotInc);}
    }
 
    public void ButtonRotationRight()
    {
        if (serialEnabled){_serial.Write("rr" + Rotation.rotInc);}
    }

    public void ButtonElevationUp()
    {
        if (serialEnabled){_serial.Write("er" + Elevation.percent);}
    }

    public void ButtonElevationDown()
    {
        if (serialEnabled){_serial.Write("er" + -1*Elevation.percent);}
    }

    
    public void DropBall()
    {
        if (serialEnabled){_serial.Write("dd-70");}
    }


     // Reset command for ramp on Unity and prompt to serial monitor for reset
    public void ResetCommand()
    {

        Elevation.ResetHeight();
        Rotation.ResetAngle();
        
        Debug.Log(output_reset);
        if (serialEnabled){_serial.Write(output_reset.ToString());}

    }
    

    //Calibration command to firmware
    public void CalibrationCommand()
    {

        // Elevation.ResetHeight();
        // Rotation.ResetAngle();
        Debug.Log("Calibration " + output_calibration);
        if (serialEnabled) { _serial.Write(output_calibration); }
    }

    public void ConnectToPort()
    {
        // string[] ports = SerialPort.GetPortNames();
        // Debug.Log(ports);
        try      
        {
            // Get the port we want to connect to from the dropdown
            
            _serial = new SerialPort(COMPort, 9600)
            {
                Encoding = System.Text.Encoding.UTF8,
                DtrEnable = true
            };
    
            _serial.Open();
            Debug.Log("Connected to port: " + COMPort);
            

            // string dataToSend = "Hello";
            // _serial.WriteLine(dataToSend);
            
            serialEnabled = true;
        }

        catch (Exception ex)
        {
            Debug.Log(ex.Message);
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

            Debug.Log("Disconnected");
            serialEnabled = false;
        }
    }

}