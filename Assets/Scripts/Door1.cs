using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door1 : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Level.current.addCoins(1);
        this.CollectedHide();
        SceneManager.LoadScene("Level1");
    }
}
