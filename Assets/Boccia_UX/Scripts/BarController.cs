using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    Animator barAnim;
    public Rigidbody ball;

    public void DropButtonPressed() {       
        barAnim.SetBool("isOpening", true);        
        Invoke("Close", 1f);

        Vector3 pushForce = new(0, -1, 0);
        ball.WakeUp();
        ball.AddForce(pushForce, ForceMode.Impulse);
        Debug.Log("You have pushed");
    }

    void Close() {
        barAnim.SetBool("isOpening", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        barAnim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
