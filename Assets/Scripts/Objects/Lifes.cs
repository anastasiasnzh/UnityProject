using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        LevelController.current.addLifes();
        
        this.CollectedHide();
    }
}
