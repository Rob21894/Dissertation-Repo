using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CarControl : MonoBehaviour {
    public InputDevice inputDevice;
    // Use this for initialization
    public Animator anim;

    public enum playerState { Idle, Driving, Pause, Dead };
    public playerState playerStates = playerState.Idle;
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        inputDevice = InputManager.ActiveDevice;

        if (inputDevice != InputDevice.Null && inputDevice != TouchManager.Device)
        {
            TouchManager.ControlsEnabled = false;
        }

    }
}
