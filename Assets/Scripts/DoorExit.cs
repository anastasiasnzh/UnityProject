using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : Collectable


{

    public GameObject winPrefab;
    public AudioClip winSound = null;

    AudioSource winSource = null;

    void Start()
    {
        winSource = gameObject.AddComponent<AudioSource>();
        winSource.clip = winSound;
    }

    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Level.current.addCoins(1);
        this.CollectedHide();
        //GameController.current.setCurrentLevel(0);
        this.showSettings();
        
    }

    void showSettings()
    {
        //Знайти батьківський елемент
        GameObject parent = UICamera.first.transform.parent.gameObject;
        //Створити Prefab
        GameObject obj = NGUITools.AddChild(parent, winPrefab);
        //Отримати доступ до компоненту (щоб передати параметри)
        WinPopUp popup = obj.GetComponent<WinPopUp>();
        //...

        //popup.setFruitsCounts(3, 13);//
    }
}