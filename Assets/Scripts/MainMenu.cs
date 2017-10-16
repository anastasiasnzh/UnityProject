using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public MyButton playButton;
    public MyButton settingsButton;
    void Start()
    {
        //Debug.Log("MainMenu.Start");
        playButton.signalOnClick.AddListener(this.onPlay);
        settingsButton.signalOnClick.AddListener(this.onSettings);
    }
    void onPlay()
    {
        //Debug.Log("MainMenu.onPlay");
        SceneManager.LoadScene("ChooseLevelScene");
    }

    void onSettings()
    {
        //Debug.Log("quit");
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
