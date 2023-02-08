using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 myPos;
    public Quaternion startPos;
    public GameObject mainShaft;
    public Vector3 myHeight;
    public Vector3 startHeight;
    public GameObject elevationPlate;

    public float rotZ;
    public float heightZ;

    public GameObject trainingPanel;

    [SerializeField]
    private Controller selectBCI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //record starting position
        startPos=mainShaft.transform.rotation;
        //mainShaft = GameObject.Find("MainShaft");
        rotZ = mainShaft.transform.localEulerAngles.y;

        startHeight = elevationPlate.transform.position;
        heightZ = elevationPlate.transform.position.z;
        
    }

    public void P300Train()
    {
        selectBCI.GetComponent<P300Controller>().enabled = true;
        selectBCI.GetComponent<SSVEPController>().enabled = false;

    }

    public void SSVEPTrain()
    {
        selectBCI.GetComponent<SSVEPController>().enabled = true;
        selectBCI.GetComponent<P300Controller>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //Close the panel
        //    trainingPanel.SetActive(false);

        //}
    }
}
