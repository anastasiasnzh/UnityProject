using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable {

    float direction;
    public float speed = 0.01f;

    Rigidbody2D myBody = null;
    SpriteRenderer myRenderer = null;
    Animator myAnimator = null;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();

        StartCoroutine(destroyLater());
    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    public void launch(float direction)
    {
        this.direction = direction;
     

        //Vector2 vel = myBody.velocity;
        Debug.Log(myBody);

       
        if (direction < 0)
        {
            //vel.x = -1 * speed;
           
            GetComponent<SpriteRenderer>().flipX = true;
        } else if(direction >= 0)
        {
            //vel.x = speed;
          
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //Debug.Log(vel);
        //myBody.velocity = vel;

    }

   
    protected override void OnRabitHit(HeroRabit rabit)
    {
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

    void Update()
    {
        Vector3 pos = this.transform.position;
        transform.position = pos + Vector3.right * this.direction;
    }
}
