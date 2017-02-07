using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMovement : MonoBehaviour {

    public float startSpeed = 1.0f;
    public float movementSpeed = 5.0f;
    public float dist;
    PlayerControl playercontrol;
    public float jumpCharge = 10.0f;
    private bool doubleJump = false;
    private bool jumping = false;

    private float jumpdelay = 0.5f;

    private bool sliding = false;
    private float slideDuration = 1.5f;

    Rigidbody2D rb;
    [HideInInspector]
    // Use this for initialization
    void Start ()
    {
        playercontrol = GetComponent<PlayerControl>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if (playercontrol.playerStates == PlayerControl.playerState.Running)
        {
            playerRun();
            playerJump();
            playerSlide();
        }

        movementSpeed += 0.1f * Time.deltaTime;
        if (movementSpeed >= 15.0f)
        {
            movementSpeed = 15.0f;
        }
        Debug.DrawRay(transform.position, -Vector3.up * dist);
      //  Debug.Log(rb.velocity.y);
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
        // gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);
        rb.velocity = new Vector2(startSpeed, rb.velocity.y);
       
    }

    public void playerJump()
    {
        if (playercontrol.inputDevice.Action1 && checkGrounded() && !doubleJump)
        {
            jumping = true;
            playercontrol.anim.SetBool("Land", false);
            playercontrol.anim.SetBool("idleToRun", false);
            playercontrol.anim.SetBool("Jump", true);
            playercontrol.anim.SetBool("JumpFallToRun", false);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpCharge, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(0, jumpCharge), ForceMode2D.Impulse);
            //    gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.Space) && checkGrounded() && !doubleJump)
        {
            jumping = true;
            playercontrol.anim.SetBool("Land", false);
            playercontrol.anim.SetBool("idleToRun", false);
            playercontrol.anim.SetBool("Jump", true);
            playercontrol.anim.SetBool("JumpFallToRun", false);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpCharge, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(0, jumpCharge),ForceMode2D.Impulse);
        //    gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);

        }

        if (playercontrol.inputDevice.Action1 && !checkGrounded() && !doubleJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            jumping = false;
            doubleJump = true;
            gameObject.transform.Translate(Vector3.right * startSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !checkGrounded() && !doubleJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            jumping = false;
            doubleJump = true;
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
