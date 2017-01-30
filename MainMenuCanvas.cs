using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour {

    // Use this for initialization
    public GameObject mainMenu;
    public GameObject howToPlay;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void openHowToPlay()
    {
        howToPlay.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void closeHowToPlay()
    {
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
    }
}
