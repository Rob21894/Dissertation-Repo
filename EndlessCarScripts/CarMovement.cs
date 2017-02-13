using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CarMovement : MonoBehaviour
{

    // Use this for initialization
    CarControl carControl;
    public float changeLaneSpeed = 2f;
    public float laneWidth = 1;
    private float xPos;
    public float movementSpeed = 5;
    public float maxSpeed = 5.0f;
    Rigidbody rb;
    void Start()
    {
        carControl = gameObject.GetComponent<CarControl>(); // get car control script
        xPos = transform.position.x;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carControl.inputDevice.Action1 || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(MoveLane(-laneWidth));
        }

        if (carControl.inputDevice.Action2 || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(MoveLaneRight(laneWidth));
        }

        if (movementSpeed < maxSpeed)
        {
            movementSpeed += 1.0f * 2 * Time.deltaTime;
        }
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y, movementSpeed);
        Vector3 pos = transform.position;
        pos.x = xPos;
        transform.position = pos;
    }


    IEnumerator MoveLane(float offset)
    {
        float t = 0f;
        carControl.anim.SetBool("MoveLeft", true);
        while (t < 1)
        {
            t += Time.deltaTime * changeLaneSpeed;
            xPos = Mathf.Lerp(xPos, xPos + offset, t);
            if (t > 1)
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
            xPos = Mathf.Lerp(xPos, xPos + offset, t);
            if (t > 1)
            {
                carControl.anim.SetBool("MoveRight", false);
            }
            yield return null;
        }
    }

  //  IEnumerator()
}
