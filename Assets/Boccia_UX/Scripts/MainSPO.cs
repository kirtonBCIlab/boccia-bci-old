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

    [SerializeField]
    private RestTime restTime;

    [SerializeField]
    private NetworkController networkController;

    private BallReset ballReset;


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

        //Get the Rest time component from the GameController object;
        restTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<RestTime>();

        //Get the network object so we can write messages on selection. 
        //Going to use the following default ids for now (arbitrarily chosen):
        /* Marker ID 0 - Training Start Time
         * Marker ID 100 - Experiment Start Time
         * Marker ID 300 - Time On "Main" Display page
         * Marker ID 500 - Time on "Elevation" Display page
         * Marker ID 700 - Time on "Rotation" Display page
         * Marker ID 1041 - Experiment End (Ball is dropped)
         * Marker ID Case number (0-7) + 41 = Success on that case. E.g. 041 = Success on Case 0 (switch to rotation view).
         * Marker ID Case number (0-7) + 42 = Failure on that case. E.g. 042 = Fail on Case 0 (switch to rotation view).
         */
        networkController = GameObject.FindGameObjectWithTag("GameController").GetComponent<NetworkController>();

        ballReset = GameObject.FindGameObjectWithTag("GameController").GetComponent<BallReset>();
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
                    networkController.SendMessageTimeSinceStartExperiment("041, Correctly chose going to Rotation View! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("042, Wrongly chose going to Rotation View! Time since experiment start: ");
                }
                autoInstructions.ToggleMainDisplay(false);
                camScript.SwitchToRotationView();
                camScript.EnableBirdEyeView();
                autoInstructions.SetInstructionTarget();
                // autoInstructions.StartCoroutine("WaitToStartStim");
                break;
            case 1:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    networkController.SendMessageTimeSinceStartExperiment("141, Correctly chose to return to Main Menu! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("142, Wrongly chose to return to Main Menu. Time since experiment start: ");
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
                    networkController.SendMessageTimeSinceStartExperiment("241, Correctly chose switching to Elevation View! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("242, Wrongly chose switching to Elevation View! Time since experiment start: ");
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
                    networkController.SendMessageTimeSinceStartExperiment("341, Correctly dropped the ball! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");                    
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("342, Wrongly dropped the ball! Time since experiment start: ");
                }
                ballReset.GetBallDropPosition();
                barController.DropButtonPressed();

                if (autoInstructions.GetNumSelecitonTargetsLeft() == 0)
                {
                    //Call the rest time now
                    print("Time for rest, as there are no instructions left!".Color("orange"));
                    networkController.SendMessageTimeSinceStartExperiment("1041, Ball dropped end of experiment: ");
                    restTime.StartChangeText();
                }
                else
                {
                    autoInstructions.SetInstructionTarget();
                }
                break;
            case 4:
                //Todo
                //If statement to check what is happening is what is intended
                if (autoInstructions.currentTargetGO.Equals(this.gameObject))
                {
                    Debug.Log("You selected the correct one!".Color("green"));
                    networkController.SendMessageTimeSinceStartExperiment("441, Correctly rotated left (s)! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("442, Wrongly chose to rotate left (s). Time since experiment start: ");
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
                    networkController.SendMessageTimeSinceStartExperiment("541, Correctly rotated right (s)! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("542, Wrongly chose to rotate right (s). Time since experiment start: ");
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
                    networkController.SendMessageTimeSinceStartExperiment("641, Correctly moved up! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("642, Wrongly chose to move up. Time since experiment start: ");
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
                    networkController.SendMessageTimeSinceStartExperiment("741, Correctly moved down! Time since experiment start: ");
                    Debug.Log("Cleaning the selection targets...");
                    autoInstructions.needToCleanList = true;
                    autoInstructions.CleanUpInstructionTargets();
                }
                else
                {
                    Debug.Log("Wrong target was selected, not cleaning the list".Color("red"));
                    networkController.SendMessageTimeSinceStartExperiment("742, Wrongly moved down! Time since experiment start: ");
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
