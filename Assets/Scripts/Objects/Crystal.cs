using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable
{
    

    SpriteRenderer sr;
    public bool visible = true;

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Level.current.addCoins(1);
        this.CollectedHide();
       // Debug.Log("OnRabitHit");
        if (this.name == "CrystalBlue")
        {
            //Debug.Log("else if");
            LevelController.current.blueCr.show();
        }else if (this.name == "CrystalGreen")
        {
            //Debug.Log("else if");
            LevelController.current.greenCr.show();
        }else if (this.name == "CrystalRed")
        {
            //Debug.Log("else if");
            LevelController.current.redCr.show();
        }

    }

    
}
