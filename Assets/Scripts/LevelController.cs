using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public Life life1;
    public Life life2;
    public Life life3;

    public CrystalIcon blueCr;
    public CrystalIcon greenCr;
    public CrystalIcon redCr;

    public int lifes = 3;

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
        
        this.lifes--;
        if (lifes == 2)
        {
            life3.hide();
        }else if (lifes == 1)
        {
            life2.hide();
        }
        //life3.visible = false;
        if (this.lifes <= 0)
        {
            life1.hide();
            SceneManager.LoadScene("ChooseLevelScene");
            life1.show();
            life2.show();
            life3.show();
        }
        //rabit.transform.position = this.startingPosition;
        StartCoroutine(retrunLater(rabit));
        
    }

    IEnumerator retrunLater(HeroRabit rabit)
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(2);
        
        rabit.restore();
        rabit.transform.position = this.startingPosition;
        //Continue excution in few seconds
        //Other actions...
        
    }



}
