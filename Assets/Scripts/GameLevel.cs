using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel{

    bool crystalBlue = false;
    bool crystalGreen = false;
    bool crystalRed = false;
    int fruitOnLevel = 0;
    int fruitFound = 0;
    bool levelCompleted = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addCrystal(int crNu) 
    {
        if (crNu == 1)
        {
            crystalBlue = true;
        }else if(crNu == 2)
        {
            crystalGreen = true;
        }else if (crNu == 3)
        {
            crystalRed = true;
        }
    }
}
