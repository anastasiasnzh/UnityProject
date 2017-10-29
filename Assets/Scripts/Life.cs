using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    UI2DSprite sr;
   public bool visible = true;
    void Start()
    {
        sr = this.GetComponent<UI2DSprite>();
    }
    
    

    public void show()
    {
        //Debug.Log("show");
        sr.enabled = true;
    }
    public void hide()
    {
        //Debug.Log("hide");
        sr.enabled = false;
    }

}
