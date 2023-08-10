using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialButtonToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public Text buttonText;
    private bool isOn = false;


    void Start()
    {
    Button button = GameObject.Find("SerialMonitorToggle").GetComponent<Button>();
    button.onClick.AddListener(ToggleButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleButton()
    {
        isOn = !isOn;

        if (isOn)
        {
            buttonText.text = "Serial Monitor: On";
            // You can perform other actions when the button is turned on
        }
        else
        {
            buttonText.text = "Serial Monitor: Off";
            // You can perform other actions when the button is turned off
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    public Text buttonText;
    private bool isOn = false;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleButton);
    }

    private void ToggleButton()
    {
        isOn = !isOn;

        if (isOn)
        {
            buttonText.text = "On";
            // You can perform other actions when the button is turned on
        }
        else
        {
            buttonText.text = "Off";
            // You can perform other actions when the button is turned off
        }
    }
}