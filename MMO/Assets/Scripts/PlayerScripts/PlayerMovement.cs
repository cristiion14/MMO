using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    private Rigidbody2D rb;


    public Transform groundPos;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;


    float timeToAttack = 0;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool doubleJump;
    bool canAttack = false;

    private Animator anim;

    public Image HealthBar;
    public float MaxHealth;
    public float CurrentHealth;
    public Text HealthPercentDisplay;

    public float dmgdonetest;




    private void Start()
    {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        verifyIfIsGrounded();
        verifyMovement();
        takeDamage(dmgdonetest);

        Debug.LogError(isGrounded);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            anim.SetBool("canAttack", false);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.LogError(collision.collider.name+ " " + collision.collider.tag);

        if (collision.gameObject.tag == "EnemySword")
        {
            CurrentHealth -= 5;
            Debug.Log("Ti-a dat fraieru");
        }
        if (collision.collider.tag == "Ground")
        {
          //  isGrounded = true;
          //  Debug.Log("GroundCheckPlayer");
        }
        if(collision.gameObject.tag == "EnemyArrow")
        {
            CurrentHealth -= 15;
        }
    }


    public void verifyIfIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
    }

    public void verifyMovement()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {

            Debug.LogError("Should start jumping");

            anim.SetBool("isJumping", true);

            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        else
        {
            anim.SetBool("isJumping", false);
        }

        if(isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        //{
        //    if (jumpTimeCounter > 0)
        //    {
        //        rb.velocity = Vector2.up * jumpForce;
        //        jumpTimeCounter -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        isJumping = false;
        //    }
        //}

        
        //attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("canAttack", true);
            timeToAttack = Time.time;

        }



        if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            doubleJump = true;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (!Input.anyKey)
        {
            anim.SetBool("isIdle", true);
        }
    }

    public void takeDamage(float amount)
    {
        CurrentHealth -= amount;
        HealthBar.fillAmount = (CurrentHealth/MaxHealth);
        int hpDisplay =(int)((CurrentHealth / MaxHealth) * 100);
        if(hpDisplay < 0 )
        {
            HealthPercentDisplay.text = "0 %";

        }
        else
        HealthPercentDisplay.text =hpDisplay.ToString() + " %";

    }


}

