using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    [SerializeField]
    private LSLMarkerStream markers;
    private float startTime;
    private float timeUpdate;
    public float[] eventStartTime;
    public float[] eventUpdateTime;


    private void WriteMessage(string myMessage)
    {
        markers.Write(myMessage);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SendMessageStartExperiment();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SendMessageTimeSinceStartExperiment("Event was done that we wanted to know at : ");
        }
    }

    /// <summary>
    /// This is a specific call to start the experiment timer. This should only be run once.
    /// </summary>
    public void SendMessageStartExperiment()
    {
        //Debug.Log("Sending marker that says - Starting Experiment, plus timestamp");
        SetExperimentTimeStart();
        WriteMessage("Starting Experiment: " + startTime.ToString());
    }

    /// <summary>
    /// This is a specific call to check how long it has been since the experiment start. 
    /// </summary>
    /// <param name="myMessage"></param>
    public void SendMessageTimeSinceStartExperiment(string myMessage)
    {
        //Debug.Log("Sending marker that says time since start timestamp");
        GetTimeSinceExperimentStart();
        WriteMessage(myMessage + timeUpdate.ToString());
    }

    /// <summary>
    /// Set the experiment start time.
    /// </summary>
    public void SetExperimentTimeStart()
    {
        startTime = Time.time;
        Debug.Log("Start Time set as: " + startTime);
    }

    /// <summary>
    /// Get the time since experimetn start
    /// </summary>
    public void GetTimeSinceExperimentStart()
    {
        timeUpdate = Time.time - startTime;
        Debug.Log("Updated time since start: Total difference is " + timeUpdate);
    }


    //TODO: Refactor to only put 1 input as string.
    /// <summary>
    /// Send a message about the start of an arbitrary event marker
    /// </summary>
    /// <param name="myMessage"></param>
    public void SendMessageEventStartTime(string myMessage,int eventNum)
    {
        eventStartTime[eventNum] = Time.time;
        WriteMessage(myMessage + eventStartTime[eventNum].ToString());
    }


    //TODO: Refactor to only put 1 input as string.
    /// <summary>
    /// Send a message about the update from an arbitrary event marker
    /// </summary>
    /// <param name="myMessage"></param>
    /// <param name="startEventNum"></param>
    /// <param name="eventNum"></param>
    public void SendMessageTimeSinceEventStart(string myMessage, int startEventNum, int eventNum)
    {
        eventUpdateTime[eventNum] = Time.time - eventStartTime[startEventNum];
        WriteMessage(myMessage + eventUpdateTime[eventNum].ToString());
    }


}
