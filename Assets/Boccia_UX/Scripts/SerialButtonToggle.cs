using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SerialButtonToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI buttonText;
    private bool isOn = false;


    void Start()
    {

        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToggleButton);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleButton()
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
