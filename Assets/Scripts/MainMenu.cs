using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public MyButton playButton;
    public MyButton settingsButton;
    public GameObject settingsPrefab;
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
        //Знайти батьківський елемент
        GameObject parent = UICamera.first.transform.parent.gameObject;
        //Створити Prefab
        GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
        //Отримати доступ до компоненту (щоб передати параметри)
        SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
        //...
    }

    // Update is called once per frame
    void Update () {
		
	}
}
