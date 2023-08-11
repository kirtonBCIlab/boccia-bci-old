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

    public int output_calibration = 8700;
    public int output_reset = 8800;

    private bool serialEnabled = false; 

    public String COMPort = "COM4"; 

    // Start is called before the first frame update
    void Start()
    {   
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
        float output = -2000-Rotation.rotInc;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
        
    }
 
    public void ButtonRotationRight()
    {
        float output = 2000+Rotation.rotInc;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    }

    public void ButtonElevationUp()
    {
        float output = 4000+Elevation.percent;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    }

    public void ButtonElevationDown()
    {
        float output = -4000 -  Elevation.percent;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    
    }

    
    public void DropBall()
    {
        float output = -1070;
        Debug.Log(output);
        if (serialEnabled){_serial.Write(output.ToString());}
    
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

        Elevation.ResetHeight();
        Rotation.ResetAngle();

        Debug.Log(output_calibration);
        if (serialEnabled){_serial.Write(output_calibration.ToString());}
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