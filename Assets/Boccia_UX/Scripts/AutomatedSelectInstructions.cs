using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AutomatedSelectInstructions : MonoBehaviour
{

    public Color onTargetColor;
    public Color offTargetColor;

    [SerializeField]
    private Controller bciController;

    public string nextTarget;
    public string currentTarget;
    public string defaultTarget = "BackButton";

    private List<string> selectionTargets = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

        selectionTargets.Add("ElevationButton");
        selectionTargets.Add("UpButton");
        selectionTargets.Add("BackButton");
        selectionTargets.Add("RotationButton");
        selectionTargets.Add("SLeft");
        selectionTargets.Add("BackButton");
        selectionTargets.Add("DropButton");

        //selectionTargets.Add("ElevationButton", "UpButton", "BackButton","RotationButton","SLeft","BackButton","DropButton");

        //for (int i = 0; i < selectionTargets.Count; i++)
        //    Debug.Log(selectionTargets[i] + ":" +);

        currentTarget = selectionTargets.LastOrDefault(); //last element in the list

    }



    public void CheckDisplay()
    {
        foreach (GameObject selectObject in bciController.objectList)
        {
            
        }









        if (bciController.objectList.name.Contains(currentTarget))
        {
            nextTarget = currentTarget;
        }
        else
            selectionTargets.Add("BackButton");
        //Idk how to make sure this adds in the spot and doesnt replace or move it to the end
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Highlighting the Button to Select
    public virtual void OnTargetButton() //pass in the object to highlight
    {
        { this.GetComponent<Image>().color = onTargetColor; }
    }

    // Turn off highlighting before stimulus
    public virtual void OffTargetButton()
    {
        { this.GetComponent<Image>().color = offTargetColor; }
    }
}