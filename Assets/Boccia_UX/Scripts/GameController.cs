using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NetworkController),typeof(AutomatedSelectInstructions))]
public class GameController : MonoBehaviour
{
    public Vector3 myPos;
    public Quaternion startPos;
    public GameObject mainShaft;
    public Vector3 myHeight;
    public Vector3 startHeight;
    public GameObject elevationPlate;

    [SerializeField]
    private NetworkController networkController;

    [SerializeField]
    private AutomatedSelectInstructions autoInstructions;

    public float rotZ;
    public float heightZ;

    public InstructionsText instructionsText;
    
    // Start is called before the first frame update
    void Start()
    {
        //record starting position
        startPos=mainShaft.transform.rotation;
        //mainShaft = GameObject.Find("MainShaft");
        rotZ = mainShaft.transform.localEulerAngles.y;

        startHeight = elevationPlate.transform.position;
        heightZ = elevationPlate.transform.position.z;

        //Initialize our components
        networkController = this.GetComponent<NetworkController>();
        autoInstructions = this.GetComponent<AutomatedSelectInstructions>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            instructionsText.StartChangeText();
        }   

        //Use "B" to begin experiment
        if(Input.GetKeyDown(KeyCode.B))
        {
            print("Starting the experiment".Color("yellow"));
            networkController.SendMessageStartExperiment();
            autoInstructions.SetInstructionTarget();

        }
    }

}

// This is the extension method.
// The first parameter takes the "this" modifier
// and specifies the type for which the method is defined.
public static class StringExtension
{
    public static string Bold(this string str) => "<b>" + str + "</b>";
    public static string Color(this string str, string clr) => string.Format("<color={0}>{1}</color>", clr, str);
    public static string Italic(this string str) => "<i>" + str + "</i>";
    public static string Size(this string str, int size) => string.Format("<size={0}>{1}</size>", size, str);
}