using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InstructionsText : MonoBehaviour
{
    public TMP_Text TitleText;
    public Image background;
    public int focusTimeSec;
    public int countFrom;

    private string stimText = "Stimulus will begin in...";  
    // Start is called before the first frame update
    void Start()
    {
        //TitleText.gameObject.SetActive(false);
        StartCoroutine(ChangeTextTitle());
    }

    private IEnumerator ChangeTextTitle()
    {
        background.enabled = true;
        TitleText.gameObject.SetActive(true);

        TitleText.text = "Focus on  the selected target";
        yield return new WaitForSecondsRealtime(focusTimeSec);

        
        TitleText.text = stimText.PadRight(stimText.Length);
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(BackwardsCounter(countFrom));
    }

    private IEnumerator BackwardsCounter(int countFrom)
    {        
        for (int i = countFrom; i > 0; i--)
        {
            TitleText.text = stimText + i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        TitleText.gameObject.SetActive(false);
        background.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
