using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class RestTime : MonoBehaviour
{

    public Canvas restCanvas;
    public TMP_Text restText; //Say "Rest Time Remaining"
    public TMP_Text timerText; // Show time countdown
    public Image background;

    [SerializeField]
    private float timeLeft = 120f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartChangeText()
    {
        StartCoroutine(ChangeTextTitle());
    }

    public void StopChangeText()
    {
        StopCoroutine(ChangeTextTitle());
    }

    private IEnumerator ChangeTextTitle()
    {
        restCanvas.enabled = true;
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            yield return new WaitForSecondsRealtime(1f);
        }
        else
        {
            //timer has ended
            timerText.text = "00:00";
            restText.text = "Rest is Over";
            yield return new WaitForSecondsRealtime(3f); //show the text for 3 seconds
            //turn of Canvas
            restCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}