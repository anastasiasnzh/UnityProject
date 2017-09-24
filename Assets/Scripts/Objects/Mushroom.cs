using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Level.current.addCoins(1);
        this.CollectedHide();
        if (rabit.isBig == false)
        {
            rabit.isBig = true;//
            rabit.transform.localScale += new Vector3(1F,1F,0);
        }
    }
}
