using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Car_Canvas_Control : MonoBehaviour
{

    public Text spaceToStart;
    public Text cogScore;
    public CarControl carControl;

    public Text cogsCollected;
    public Text distanceTravelled;
    public Text totalScore;

    public GameObject mainCanvas;
    public GameObject gameOverCanvas;


    public Image healthBar;
    [HideInInspector]
    public float healthAmount = 1;

    private float tempDistance = 0;
    private float tempScore = 0;
    private float tempTotalScore = 0;
    int prefs = 0;
    // Use this for initialization
    void Start()
    {

        prefs = PlayerPrefs.GetInt("qualityPrefs");
        carControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CarControl>();
        gameOverCanvas.SetActive(false);
        prefs = 0;
        if (carControl.playerStates == CarControl.playerState.Idle)
        {
            StartCoroutine(flashText(spaceToStart));
        }

        if (prefs == 0)
        {
            PlayerPrefs.SetFloat("TotalScore", 0);
            PlayerPrefs.SetFloat("CogScore", 0);
            PlayerPrefs.SetFloat("DistanceTravelled", 0);
            PlayerPrefs.SetInt("qualityPrefs", 1);
        }
        else
        {
            tempTotalScore = PlayerPrefs.GetFloat("TotalScore");
            tempScore = PlayerPrefs.GetFloat("CogScore");
            tempDistance = PlayerPrefs.GetFloat("DistanceTravelled");
            PlayerPrefs.SetInt("qualityPrefs", 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = carControl.health;
        if (carControl == null)
        {
            carControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CarControl>();
        }
        if (carControl.playerStates == CarControl.playerState.Idle && carControl.inputDevice.Action3.WasPressed || Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            spaceToStart.gameObject.SetActive(false);
            carControl.playerStates = CarControl.playerState.Driving;
        }


        gameOverMenu();
    }

    public void gameOverMenu()
    {
        if (carControl.playerStates == CarControl.playerState.Dead)
        {
            gameOverCanvas.SetActive(true);
            mainCanvas.SetActive(false);
            //if (tempScore < playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected)
            //{
            //    PlayerPrefs.SetInt("Coins Collected", playercontrol.gameObject.GetComponent<Player_CollectCoin>().coinsCollected);
            //}


            cogsCollected.text = PlayerPrefs.GetInt("Cogs Collected").ToString();
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