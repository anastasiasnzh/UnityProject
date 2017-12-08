using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : Collectable


{

    public GameObject winPrefab;

    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Level.current.addCoins(1);
        this.CollectedHide();
        GameController.current.setCurrentLevel(0);
        this.showSettings();
        SceneManager.LoadScene("ChooseLevelScene");
    }

    void showSettings()
    {
        //Знайти батьківський елемент
        GameObject parent = UICamera.first.transform.parent.gameObject;
        //Створити Prefab
        GameObject obj = NGUITools.AddChild(parent, winPrefab);
        //Отримати доступ до компоненту (щоб передати параметри)
        SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
        //...

        //popup.setFruitsCounts(3, 13);//
    }
}