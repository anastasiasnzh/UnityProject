﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public static LevelController current;

	// Use this for initialization
	void Awake () {
        current = this;
	}

    Vector3 startingPosition;

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
        rabit.transform.position = this.startingPosition;
    }

    
    
   
}