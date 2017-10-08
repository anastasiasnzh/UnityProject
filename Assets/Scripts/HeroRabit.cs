using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabit : MonoBehaviour
{

    public float speed = 1;


    bool isGrounded = false;
    bool JumpActive = false;
    float JumpTime = 0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;

    public bool isBig = false;//
    public bool isDead = false;

    Rigidbody2D myBody = null;
    SpriteRenderer myRenderer = null;
    Animator myAnimator = null;

    Transform heroParent = null;

    public static HeroRabit lastRabit = null;


    void Awake()
    {
        lastRabit = this;
    }

    // Use this for initialization


    void Start()
    {

        myBody = this.GetComponent<Rigidbody2D>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();

        //LevelController.current.sayHello();
        LevelController.current.setStartPosition(transform.position);
        //LevelController.current.setStartPosition (this.transform.position);

        this.heroParent = this.transform.parent;
    }

    // Update is called once per frame
    

    void FixedUpdate()
    {

        float value = Input.GetAxis("Horizontal");
        Animator animator = GetComponent<Animator>();
        if (this.isGrounded)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }
        if (Mathf.Abs(value) > 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        Vector3 from = transform.position + Vector3.up * 0.3f;
        //Vector3 from = this.transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        //Vector3 to = this.transform.position + Vector3.down * 0.3f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
            //myAnimator.SetBool("jump", false);

            //Перевіряємо чи ми опинились на платформі
            if (hit.transform != null
            && hit.transform.GetComponent<MovingPlatform>() != null)
            {
                //Приліпаємо до платформи
                SetNewParent(this.transform, hit.transform);
            }
        }
        else
        {
            isGrounded = false;
            //myAnimator.SetBool('jump', true);

            //Ми в повітрі відліпаємо під платформи
            SetNewParent(this.transform, this.heroParent);

        }
        Debug.DrawLine(from, to, Color.red);

        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.jumpActive = true;
        }
        if (this.jumpActive)
        {
            if (Input.GetButton("Jump"))
            {
                this.jumpTime += Time.deltaTime;
            }
                
        }*/

        if (this.isDead)
        {
            return;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
            if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }



        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }

       /* if (this.isDead)
        {
            myAnimator.SetBool("death", true);
            myAnimator.SetTrigger("reset");
            
            isDead = false;
            
            LevelController.current.onRabitDeath(this);
            
           
            
        }
        else
        {
            myAnimator.SetBool("death", false);
        }*/
    }

    static void SetNewParent(Transform obj, Transform new_parent)
    {
        if (obj.transform.parent != new_parent)
        {
            //Засікаємо позицію у Глобальних координатах
            Vector3 pos = obj.transform.position;
            //Встановлюємо нового батька
            obj.transform.parent = new_parent;
            //Після зміни батька координати кролика зміняться
            //Оскільки вони тепер відносно іншого об’єкта
            //повертаємо кролика в ті самі глобальні координати
            obj.transform.position = pos;
        }
    }

    public void die()
    {
        myAnimator.SetBool("death", true);
        GetComponent<BoxCollider2D>().enabled = false;
        myBody.isKinematic = true;
        isDead = true;
        myBody.velocity = Vector2.zero;
        LevelController.current.onRabitDeath(this);
        //StartCoroutine(restoreAfterWait());
        

    }
    

    public void restore()
    {
        myAnimator.SetBool("death", false);
        myAnimator.SetTrigger("reset");
        GetComponent<BoxCollider2D>().enabled = true;
        myBody.isKinematic = false;
        isDead = false;
        if(isBig == true)
        {
            isBig = false;
            this.transform.localScale -= new Vector3(1F, 1F, 0);
        }
        //LevelController.current.onRabitDeath(this);
    }
    

    
}
