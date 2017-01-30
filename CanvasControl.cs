using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CanvasControl : MonoBehaviour {

    public Text spaceToStart;
    public Text coinScore;
    public PlayerControl playercontrol;
	// Use this for initialization
	void Start ()
    {
        playercontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        if (playercontrol.playerStates == PlayerControl.playerState.Idle)
        {
            StartCoroutine(flashText(spaceToStart));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playercontrol == null)
        {
            playercontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        }
	   if (playercontrol.playerStates == PlayerControl.playerState.Idle && playercontrol.inputDevice.MenuWasPressed || Input.GetKeyDown(KeyCode.Space))
        {      
            StopAllCoroutines();
            spaceToStart.gameObject.SetActive(false);
            playercontrol.playerStates = PlayerControl.playerState.Running;
        }

        coinScore.text = "Score: " + playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected.ToString();
	}

    public IEnumerator flashText(Text text)
    {
        bool start = false;
        while (!start)
        {

            text.CrossFadeAlpha(0, .5f, true);
            yield return new WaitForSeconds(.5f);
            text.CrossFadeAlpha(1, .5f, true);
            yield return new WaitForSeconds(.5f);
        }

    }
}
