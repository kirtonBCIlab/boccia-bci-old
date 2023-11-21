using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T2SDrop : MonoBehaviour
{
    public GameObject MainDisplay;
    public Button DropButton;
    
    [Tooltip("Wait time to get another ball drop [sec]")]
    public float waitTime;
    
    private float lastTime;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0.0f;        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;     // Reset current time each frame

        // Check that the button is not pressed too often
        if ((currentTime - lastTime) > waitTime)
        {
            // Press drop button if we are on main display
            if (MainDisplay.activeSelf && Input.GetKeyDown(KeyCode.D))
            {
                DropButton.onClick.Invoke();
                lastTime = Time.time;
            }
        }     

    }
}
