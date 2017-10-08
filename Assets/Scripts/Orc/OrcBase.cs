using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBase : MonoBehaviour {

    public float speed = 1;

    Rigidbody2D myBody = null;
    SpriteRenderer myRenderer = null;
    Animator myAnimator = null;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 rabit_pos;

    bool isDead = false;

    public Vector3 pointBdiff;

    //public bool isDead = false;


    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        pointA = this.transform.position;//+...
        pointB = pointA + pointBdiff;
        rabit_pos = HeroRabit.lastRabit.transform.position;
    }

    
    

    bool isArrived(Vector3 pos)
    {
        Vector3 target = Vector3.zero;
        pos.z = 0;
        target.z = 0;
        //return Vector3.Distance(pos, target) < 0.2f;
        return Vector3.Distance(pos, target) < 0.02f;
    }

    public enum Mode
    {
        GoToA,
        GoToB,
        Attack
        //...
    }
    Mode mode = Mode.GoToA;


    protected virtual bool shouldPatrolAB()
    {
        return true;
    }


    

    float getDirection()
    {
        if (isDead)
        {
            return 0;
        }
        if (shouldPatrolAB())
        {
            if (mode == Mode.GoToA)
            {
                if (isArrived(pointA))
                {
                    mode = Mode.GoToB;
                    //return 1;
                }
            }
            else if (mode == Mode.GoToB)
            {
                if (isArrived(pointB))
                {
                    mode = Mode.GoToA;
                    //return -1;
                }
            }
        
        }

        Vector3 target = Vector3.zero;
        Vector3 my_pos = this.transform.position;
        if (mode == Mode.GoToA)
        {
            //Direction depending on target
            if (my_pos.x < pointA.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //if(Math.Abs(target.x-))

        if (rabit_pos.x > Mathf.Min(pointA.x, pointB.x)&& rabit_pos.x < Mathf.Max(pointA.x, pointB.x))
        {
            mode = Mode.Attack;
        }
        if (mode == Mode.Attack)
        {
            //Move towards rabit
            if (my_pos.x < rabit_pos.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }



        return 0;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        //float value = Input.GetAxis("Horizontal");
        float value = this.getDirection();

        Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        

        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            myRenderer.flipX = false;//
        }
        else if (value > 0)
        {
            myRenderer.flipX = true;//
        }

        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Намагаємося отримати компонент кролика
        HeroRabit rabit = collider.GetComponent<HeroRabit>();
        //Впасти міг не тільки кролик
        if (rabit != null)
        {
            onCollideWithRabit(rabit);
        }
    }

     void onCollideWithRabit(HeroRabit rabit)
    {
        if (this.isDead || rabit.isDead)
        {
            return;
        }
        float rabit_y = rabit.transform.position.y;
        float my_y = this.transform.position.y;
        if(my_y<rabit_y && rabit_y - my_y > 0.5f)
        {
            this.orcDie();
        }
    }

     void orcDie()
    {
        this.myAnimator.SetBool("death", true);
        this.isDead = true;
        myBody.isKinematic = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
       
        StartCoroutine(hideMeLater());
    }

    IEnumerator hideMeLater()
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        //Continue excution in few seconds
        //Other actions...
    }

    public void die()
    {
        this.isDead = true;
        myAnimator.SetBool("death", true);
        //LevelController.current.onRabitDeath(this);
        //StartCoroutine(this.restart());
    }

    IEnumerator restart()
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        //Continue excution in few seconds
        //Other actions...
    }

    protected virtual void performAttack()
    {

    }
}
