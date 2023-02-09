using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InstructionsText : MonoBehaviour
{
    public Canvas canvasText;
    public TMP_Text titleText;
    public Image background;
    public int focusTimeSec;
    public int countFrom;

    private string stimText = "Stimulus will begin in..."; 
    
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
        canvasText.enabled = true;
        titleText.text = "Focus on the selected target";
        yield return new WaitForSecondsRealtime(focusTimeSec);

        
        titleText.text = stimText.PadRight(stimText.Length);
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(BackwardsCounter(countFrom));
    }

    private IEnumerator BackwardsCounter(int countFrom)
    {        
        for (int i = countFrom; i > 0; i--)
        {
            titleText.text = stimText + i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        canvasText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
