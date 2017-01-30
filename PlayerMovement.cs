using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMovement : MonoBehaviour {

    public float startSpeed = 1.0f;
    public float movementSpeed = 5.0f;
    public float dist;
    PlayerControl playercontrol;
    private bool doubleJump = false;
    private bool jumping = false;

    private float jumpdelay = 0.5f;

    private bool sliding = false;
    private float slideDuration = 1.5f;

    [HideInInspector]
    // Use this for initialization
    void Start ()
    {
        playercontrol = GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (playercontrol.playerStates == PlayerControl.playerState.Running)
        {
            playerRun();
            playerJump();
            playerSlide();
        }

        
        Debug.DrawRay(transform.position, -Vector3.up * dist);
	}

    public void playerIsIdle()
    {
        
    }

    public void playerRun()
    {
        if (startSpeed < movementSpeed)
        {
            startSpeed += 1.0f * 2 * Time.deltaTime;
        }
        gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);
    }

    public void playerJump()
    {
        if (playercontrol.inputDevice.Action1 && checkGrounded())
        {
            jumping = true;
            playercontrol.anim.SetBool("Land", false);
            playercontrol.anim.SetBool("idleToRun", false);
            playercontrol.anim.SetBool("Jump",true);
            playercontrol.anim.SetBool("JumpFallToRun", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10, ForceMode2D.Impulse);
            gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);

        }

        if (playercontrol.inputDevice.Action1 && !checkGrounded() && !doubleJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            jumping = false;
            doubleJump = true;
            Debug.Log(doubleJump);
            gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);
        }

        if (checkGrounded() && !jumping && !sliding)
        {
            doubleJump = false;
            playercontrol.anim.SetBool("Jump", false);
            playercontrol.anim.SetBool("idleToRun", true);
            playercontrol.anim.SetBool("JumpFallToRun", true);
        }

        if (jumping)
        {
            jumpdelay -= 1.0f * Time.deltaTime;

            if (jumpdelay <= 0)
            {
                playercontrol.anim.SetBool("Land", true);
                jumpdelay = 0.5f;
                jumping = false;
            }
        }
    }

    public void playerSlide()
    {
        if (playercontrol.inputDevice.Action2 && checkGrounded() && !sliding)
        {
            playercontrol.anim.SetBool("Slide", true);
            playercontrol.anim.SetBool("Land", false);
            playercontrol.anim.SetBool("SlideToRun", false);
            playercontrol.anim.SetBool("idleToRun", false);
            playercontrol.anim.SetBool("Jump", false);
            playercontrol.anim.SetBool("JumpFallToRun", false);
            sliding = true;
        }

        if (sliding)
        {
            slideDuration -= 1.0f * Time.deltaTime;
            if (slideDuration <= 0.0f)
            {
                playercontrol.anim.SetBool("Slide", false);
                playercontrol.anim.SetBool("SlideToRun", true);
                slideDuration = 1.5f;
                sliding = false;
            }
        }
    }

    public bool checkGrounded()
    {

        if (Physics2D.Raycast(transform.position, -Vector3.up, dist, 1 << 9))
        {
            return true;
        }
        else
        return false;
    }

    
}
