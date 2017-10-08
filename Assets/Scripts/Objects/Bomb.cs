using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Level.current.addCoins(1);
        this.CollectedHide();
        if (rabit.isBig == false)
        {

            //rabit.isDead = true;
            //LevelController.current.onRabitDeath(rabit);
            rabit.die();
            //StartCoroutine(restart(rabit));
            //rabit.restore();


        }
        else
        {
            rabit.isBig = false;
            rabit.transform.localScale -= new Vector3(1F, 1F, 0);
        }
    }

    IEnumerator restart(HeroRabit rabit)
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(3);
        //rabit.restore();
        //Continue excution in few seconds
        //Other actions...
    }



}
