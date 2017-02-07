using UnityEngine;
using System.Collections;
using InControl;

public class PlayerControl : MonoBehaviour {

    public enum playerState { Idle, Running, Jumping, Pause, Dead };
    public playerState playerStates = playerState.Idle;

    public Animator anim;
    // Use this for initialization
    public InputDevice inputDevice;
    public bool shieldIsActive = false;
    public GameObject shield;
    public bool playerHit = false;
    PlayerMovement playerMovement;
    void Start ()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputDevice = InputManager.ActiveDevice;

        if (inputDevice != InputDevice.Null && inputDevice != TouchManager.Device)
        {
            TouchManager.ControlsEnabled = false;
        }

        if (shieldIsActive)
        {
            shield.SetActive(true);
        }
        else
            shield.SetActive(false);
        //  touchControl.ActiveArea.Set(gameObject.transform.position.x - 20.0f, -1.33f, 146.4f, 107.8f);



        if (transform.position.y <= -10.0f)
        {
            playerStates = playerState.Dead;
        }

        if (playerStates == playerState.Dead)
        {
            playerMovement.movementSpeed = 0;
        }
    }

    public void playerStateControl()
    {
        if (playerStates == playerState.Idle)
        {
            anim.SetBool("idleToRun", false);
        }
        if (playerStates == playerState.Running)
        {
           // anim.SetBool("idleToRun", true);
        }
    }


    IEnumerator flashPlayer()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        while (playerHit)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);
            yield return new WaitForSeconds(.2f);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
            yield return new WaitForSeconds(.2f);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);
            yield return new WaitForSeconds(.2f);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
            yield return new WaitForSeconds(.2f);
            playerHit = false;
        }
    }

    public void startFlash()
    {
        StartCoroutine(flashPlayer());
    }

}
