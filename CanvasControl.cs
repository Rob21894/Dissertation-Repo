using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CanvasControl : MonoBehaviour {

    public Text spaceToStart;
    public Text coinScore;
    public PlayerControl playercontrol;

    public Text coinsCollected;
    public Text sprayCansCollected;
    public Text totalScore;

    public GameObject mainCanvas;
    public GameObject gameOverCanvas;

    private int tempCoinscollected = 0;
    private int tempSprayCansCollected = 0;
    private int tempTotalScore = 0;
    int prefs = 0;
	// Use this for initialization
	void Start ()
    {
        prefs = PlayerPrefs.GetInt("qualityPrefs");
        playercontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        gameOverCanvas.SetActive(false);
        if (playercontrol.playerStates == PlayerControl.playerState.Idle)
        {
            StartCoroutine(flashText(spaceToStart));
        }

        if (prefs == 0)
        {
            PlayerPrefs.SetInt("Total Score", 0);
            PlayerPrefs.SetInt("Coins Collected", 0);
            PlayerPrefs.SetInt("Spray Cans Collected", 0);
            PlayerPrefs.SetInt("qualityPrefs", 1);
        }
        else
        {
            tempTotalScore = PlayerPrefs.GetInt("Total Score");
            tempCoinscollected = PlayerPrefs.GetInt("Coins Collected");
            tempSprayCansCollected = PlayerPrefs.GetInt("Spray Cans Collected");
            PlayerPrefs.SetInt("qualityPrefs", 1);
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playercontrol == null)
        {
            playercontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        }
	   if (playercontrol.playerStates == PlayerControl.playerState.Idle && playercontrol.inputDevice.Action3.WasPressed || Input.GetKeyDown(KeyCode.Space))
        {      
            StopAllCoroutines();
            spaceToStart.gameObject.SetActive(false);
            playercontrol.playerStates = PlayerControl.playerState.Running;
        }

        //  coinScore.text = "Score: " + playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected.ToString();#
        coinScore.text = playercontrol.gameObject.GetComponent<PlayerMovement>().jumpCharge.ToString();

        gameOverMenu();
	}

    public void gameOverMenu()
    {
        if (playercontrol.playerStates == PlayerControl.playerState.Dead)
        {
            gameOverCanvas.SetActive(true);
            mainCanvas.SetActive(false);
            if (tempCoinscollected < playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected)
            {
                PlayerPrefs.SetInt("Coins Collected", playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected);
            }


            coinsCollected.text = PlayerPrefs.GetInt("Coins Collected").ToString();
                //playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected.ToString();
        }
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

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
