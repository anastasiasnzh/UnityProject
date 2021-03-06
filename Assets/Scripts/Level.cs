﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int coins = 0;

    public int maxFruit = 11;
    public int collectedFruit = 0;


    public static Level current;

    public MyButton settingsPauseButton;

    bool crystalBlue = false;
    bool crystalGreen = false;
    bool crystalRed = false;
    bool levelCompleted = false;

    // Use this for initialization
    void Awake()
    {
        current = this;
    }

    private void Start()
    {
        //settingsPauseButton.signalOnClick.AddListener(this.onSettings);
        
    }
    void onSettings()
    {
        //Debug.Log("quit");
        Application.Quit();
    }

    public void addCoins (int nu)
    {
        coins = coins + nu;
    }

    public void addFruit(int nu)
    {
        collectedFruit = collectedFruit + nu;
    }

    private void Update()
    {
        UILabel lbl = GameObject.Find("CoinsLabel").GetComponent<UILabel>();
        string c = coins.ToString();
        int l = c.Length;
        if (l == 1)
        {
            c = "000" + c;
        } else if (l == 2)
        {
            c = "00" + c;
        }else if (l == 3)
        {
            c = "0" + c;
        }
        lbl.text = c;


        UILabel fruit = GameObject.Find("FruitLabel").GetComponent<UILabel>();
        fruit.text = collectedFruit.ToString()+"/"+maxFruit.ToString();

        this.coins = PlayerPrefs.GetInt("coins", 0);
        PlayerPrefs.SetInt("coins", this.coins);
        PlayerPrefs.Save();

        
    }

    public void addCrystal(int crNu)
    {
        if (crNu == 1)
        {
            crystalBlue = true;
        }
        else if (crNu == 2)
        {
            crystalGreen = true;
        }
        else if (crNu == 3)
        {
            crystalRed = true;
        }
    }

}
