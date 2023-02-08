using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    Animator barAnim;
    public Rigidbody ball;

    public void DropButtonPressed()
    {  
        StartCoroutine(BallDrop());
    }

    private IEnumerator BallDrop()
    {
        // Open lever
        barAnim.SetBool("isOpening", true);

        yield return new WaitForSecondsRealtime(1f);

        // Close lever
        barAnim.SetBool("isOpening", false);
        yield return null;
    }

    void Close() {
        barAnim.SetBool("isOpening", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        barAnim = this.transform.parent.GetComponent<Animator>();
        ball.sleepThreshold = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
