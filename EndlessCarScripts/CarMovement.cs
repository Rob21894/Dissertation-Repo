using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CarMovement : MonoBehaviour
{

    // Use this for initialization
    CarControl carControl;
    public float changeLaneSpeed = 2f;
    public float laneWidth = 3.53f;
    public float xPos = 3.53f;
    public float movementSpeed = 5;
    public float maxSpeed = 5.0f;
    public float forceamount = 0;
    public float laneTransitionSpeed = 5f;

    public float posx;
    Rigidbody rb;
    void Start()
    {
        carControl = gameObject.GetComponent<CarControl>(); // get car control script
        xPos = transform.position.x;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 pos = transform.position;
        // pos.x = -Input.acceleration.x;
        posx = pos.x;


        if (carControl.inputDevice.Action1 || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //StartCoroutine(MoveLane(-laneWidth));
            xPos = -3.53f;
           // rb.AddForce(Vector3.left * forceamount, ForceMode.Impulse);
        }

        if (carControl.inputDevice.Action2 || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //StartCoroutine(MoveLaneRight(laneWidth));
            xPos = 3.53f;
          //  rb.AddForce(Vector3.right * forceamount, ForceMode.Impulse);
        }
        //  transform.position = new Vector3(-Input.acceleration.x * 10 * Time.deltaTime, transform.position.y,transform.position.z);
        if (movementSpeed < maxSpeed)
        {
            movementSpeed += 1.0f * 2 * Time.deltaTime;
        }
        //  pos.x = Mathf.MoveTowards(transform.position.x, xPos, Time.deltaTime * changeLaneSpeed);
        // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movementSpeed);
          transform.Translate(-transform.forward * movementSpeed * Time.deltaTime);
        // pos *= Time.deltaTime;
        // transform.Translate(pos * movementSpeed);
        //pos.z += transform.forward;
        pos.x = Mathf.Lerp(pos.x, xPos, Time.deltaTime * laneTransitionSpeed);
        transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
        // transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, xPos, Time.deltaTime * changeLaneSpeed), transform.position.y, transform.position.z);
    }


    IEnumerator MoveLane(float offset)
    {
        float t = 0f;
        carControl.anim.SetBool("MoveLeft", true);
        while (t < 1)
        {
            t += Time.deltaTime * changeLaneSpeed;
            xPos = Mathf.Lerp(xPos, offset, t);
            if (t >= 1)
            {
                carControl.anim.SetBool("MoveLeft", false);
            }
            yield return null;
        }
    }

    IEnumerator MoveLaneRight(float offset)
    {
        float t = 0f;
        carControl.anim.SetBool("MoveRight", true);
        while (t < 1)
        {
            t += Time.deltaTime * changeLaneSpeed;
            xPos = Mathf.Lerp(xPos, offset, t);
            if (t >= 1)
            {
                carControl.anim.SetBool("MoveRight", false);
            }
            yield return null;
        }
    }

  //  IEnumerator()
}
