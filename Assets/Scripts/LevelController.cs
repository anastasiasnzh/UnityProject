using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public GameObject settingsPrefab;
    public GameObject losePrefab;
    public MyButton pauseButton;

    public Life life1;
    public Life life2;
    public Life life3;

    public CrystalIcon blueCr;
    public CrystalIcon greenCr;
    public CrystalIcon redCr;

    public int lifes = 3;

    public static LevelController current;

    public AudioClip music = null;
    AudioSource musicSource = null;

    // Use this for initialization
    void Awake () {
        current = this;
	}

    Vector3 startingPosition;
    private void Start()
    {
        pauseButton.signalOnClick.AddListener(this.showSettings);
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void setMusicOn(bool val)
    {
        PlayerPrefs.SetInt("music", val ? 1 : 0);
        if (val == true)
        {
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    //void Update () {

    //}

    /*public void sayHello()
    {
        Debug.Log("Hello");
    }*/

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void onRabitDeath(HeroRabit rabit)
    {
        
        lifes--;
        if (lifes == 2)
        {
            life3.hide();
        }else if (lifes == 1)
        {
            life2.hide();
        }
        //life3.visible = false;
        if (lifes <= 0)
        {
            life1.hide();
            //SceneManager.LoadScene("ChooseLevelScene");
            this.showLose();
            life1.show();
            life2.show();
            life3.show();
        }
        //rabit.transform.position = this.startingPosition;
        StartCoroutine(retrunLater(rabit));
        
    }

    IEnumerator retrunLater(HeroRabit rabit)
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(2);
        
        rabit.restore();
        rabit.transform.position = this.startingPosition;
        //Continue excution in few seconds
        //Other actions...
        
    }

    void showSettings()
    {
        //Знайти батьківський елемент
        GameObject parent = UICamera.first.transform.parent.gameObject;
        //Створити Prefab
        GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
        //Отримати доступ до компоненту (щоб передати параметри)
        SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
        //...

        //popup.setFruitsCounts(3, 13);//
    }

    void showLose()
    {
        //Знайти батьківський елемент
        GameObject parent = UICamera.first.transform.parent.gameObject;
        //Створити Prefab
        GameObject obj = NGUITools.AddChild(parent, losePrefab);
        //Отримати доступ до компоненту (щоб передати параметри)
        LosePopUp popup = obj.GetComponent<LosePopUp>();
        //...

        //popup.setFruitsCounts(3, 13);//
    }


    public void addLifes()
    {
        if (lifes < 3)
        {
            lifes++;
        }
        if (lifes == 3)
        {
            life3.show();
        }
        else if (lifes == 2)
        {
            life2.show();
        } else if (lifes == 1)
        {
            life1.show();

        }

    }
}
