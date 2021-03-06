﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc1 : MonoBehaviour {

    /*protected override bool shouldPatrolAB()
    {
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        if(rabit_pos.x)
    }*/

    /* protected override float getAttackDirection()
     {
         Vector3 rabit_pos = HeroRabit.currentRabit.transform.position;
         Vector3 my_pos = this.transform.position;
         if (Mathf.Abs(rabit_pos.x - my_pos.x) < 0.5f)
         {
             return 0;
         }
     }
     
    protected override void performAttack()
    {
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        Vector3 my_pos = this.transform.position;
        //this.myController.SetTrigger
    }*/

    public float speed = 1;

    Rigidbody2D myBody = null;
    SpriteRenderer myRenderer = null;
    Animator myAnimator = null;
    public Vector3 pointA;
    public Vector3 pointB;
    Vector3 rabit_pos;
    public AudioClip attackSound = null;
    AudioSource attackSource = null;
    bool isDead = false;

    //public Vector3 pointBdiff;

    //public bool isDead = false;


    // Use this for initialization
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        //pointA = this.transform.position-pointBdiff;//+...
        //pointB = pointA + pointBdiff;
        rabit_pos = HeroRabit.lastRabit.transform.position;
        attackSource = gameObject.AddComponent<AudioSource>();
        attackSource.clip = attackSound;
    }




    bool isArrived(Vector3 pos)
    {
        Vector3 target = this.transform.position;
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.2f;
        //return Vector3.Distance(pos, target) < 0.02f;
    }

    public enum Mode
    {
        GoToA,
        GoToB,
        Attack
        //...
    }
    Mode mode = Mode.GoToA;


    protected bool shouldPatrolAB()
    {
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        if (rabit_pos.x > Mathf.Min(pointA.x, pointB.x)
&& rabit_pos.x < Mathf.Max(pointA.x, pointB.x) && Mathf.Abs(rabit_pos.y - this.transform.position.y) < 3)
        {
            mode = Mode.Attack;
            return false;
        }
        else
        {

            return true;
        }
    }




    float getDirection()
    {
        if (isDead)
        {
            return 0;
        }

        //Debug.Log(shouldPatrolAB());

        if (shouldPatrolAB())
        {
        if(mode == Mode.Attack)
            {
                mode = Mode.GoToA;
            }
        if (mode == Mode.GoToA)
            {
                if (isArrived(pointA))
                {
                    mode = Mode.GoToB;
                    //Debug.Log("GoToB");
                    
                }
                //return -1;
            }
            else if (mode == Mode.GoToB)
            {
                if (isArrived(pointB))
                {
                    mode = Mode.GoToA;
                    //Debug.Log("GoToA");

                }
                //return 1;
            }

        }

        Vector3 target = Vector3.zero;
        Vector3 my_pos = this.transform.position;
        if (mode == Mode.GoToA)
        {
            //Debug.Log("GoToA");
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

        if (mode == Mode.GoToB)
        {
            //Debug.Log("GoToB");
            //Direction depending on target
            if (my_pos.x < pointB.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //if(Math.Abs(target.x-))

        /*if (rabit_pos.x > Mathf.Min(pointA.x, pointB.x) && rabit_pos.x < Mathf.Max(pointA.x, pointB.x))
        {
            mode = Mode.Attack;
            //Debug.Log("Attack");
        }*/
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        if(mode == Mode.Attack)
        {
            if (isArrived(rabit_pos))
            {
                mode = Mode.GoToA;
            }
        }
        if (mode == Mode.Attack)
        {
            //Debug.Log("Attack");
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
        this.myAnimator.SetTrigger("attack");
        float rabit_y = rabit.transform.position.y;
        float my_y = this.transform.position.y;
        if (my_y < rabit_y && rabit_y - my_y > 0.5f)
        {
            this.orcDie();
        }
        else
        {
            rabit.die();
            myAnimator.SetBool("run", true);
            //rabit.restore();
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

    protected void performAttack()
    {
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        Vector3 my_pos = this.transform.position;
        if (SoundManager.Instance.isSoundOn())
        {
            attackSource.Play();
        }
        this.myAnimator.SetTrigger("attack");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(3);
        //Continue excution in few seconds
        //Other actions...
    }

    protected float getAttackDirection()
    {
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        Vector3 my_pos = this.transform.position;
        if (Mathf.Abs(rabit_pos.x - my_pos.x) < 0.5f)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}
