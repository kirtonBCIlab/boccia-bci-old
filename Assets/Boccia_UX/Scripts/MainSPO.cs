using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MainSPO : SPO
{
    public Color newOnColor;
    public Color newOffColor;

    [SerializeField]
    private int myObjectId;
    private string myMessage;

    [SerializeField]
    private SwitchfromMainCamera camScript;

    [SerializeField]
    private BarController barController;

    [SerializeField]
    private ElevationAdjuster elevAdj;

    [SerializeField]
    private RampRotation rampRot;

    [SerializeField]
    private AutomatedSelectInstructions autoInstructions;


    // Start is called before the first frame update
    void Start()
    {
        if(newOnColor==null)
        {
            Debug.Log("Yooooo you forgot to edit the object in the editor!");
        }
        Debug.Log(GetMyId());

        //Get the Game Controller object, and set the Automated Training Component to this object.

        autoInstructions = GameObject.FindGameObjectWithTag("GameController").GetComponent<AutomatedSelectInstructions>();

    }

    public override float TurnOn()
    {
        { this.GetComponent<Image>().color = newOnColor; }
        return Time.time;
    }

    public override void TurnOff()
    {
        { this.GetComponent<Image>().color = newOffColor; } 
        
    }


    public override void OnSelection()
    {
        switch (myObjectId)
        {
            case 0:
                //Todo - change to display or camera
                //If statement to check what is happening is what is intended
                if(autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                autoInstructions.ToggleMainDisplay(false);
                camScript.SwitchToRotationView();
                autoInstructions.SetInstructionTarget();
                break;
            case 1:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                autoInstructions.ToggleMainDisplay(true);
                camScript.SwitchToMainDisplay();
                autoInstructions.SetInstructionTarget();
                break;
            case 2:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                autoInstructions.ToggleMainDisplay(false);
                camScript.SwitchToElevationView();
                autoInstructions.SetInstructionTarget();
                break;
            case 3:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                barController.DropButtonPressed();
                autoInstructions.SetInstructionTarget();
                break;
            case 4:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                rampRot.RotateLeftS();
                autoInstructions.SetInstructionTarget();
                break;
            case 5:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                rampRot.RotateRightS();
                autoInstructions.SetInstructionTarget();
                break;
            case 6:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                elevAdj.MoveUp();
                autoInstructions.SetInstructionTarget();
                break;
            case 7:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                }
                elevAdj.MoveDown();
                autoInstructions.SetInstructionTarget();
                break;

        }
    }

    public int GetMyId()
    {
        return myObjectId;
    }

}
