using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   Vector2 moveInput;
   Rigidbody2D myRigidBody;
   [SerializeField] float moveVelocity = 3f;
   public Animator myAnimator;
   [SerializeField] float jumpSpeed = 10f;
   [SerializeField] float climbVelocity = 3f;
   [SerializeField] Vector2 deathkick = new Vector2(0f,15f);

   [SerializeField] GameObject arrow;
   [SerializeField] Transform bow;

   [SerializeField] AudioClip shootClip;
   float gravityScaleAtStart;

   CapsuleCollider2D myBodyCollider;
   BoxCollider2D myFeetCollider;

   bool isAlive = true;

   LevelManager levelManager;

   void Awake()
   {
    levelManager = FindObjectOfType<LevelManager>();
   }


    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

   
    void Update()
    {
        if(!isAlive){return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value)
    {
        if(!isAlive){return;}
        if(value.isPressed)
        {
            AudioSource.PlayClipAtPoint(shootClip,transform.position, 1f);
            arrow.transform.localScale = myRigidBody.transform.localScale;
             Instantiate(arrow,bow.position,transform.rotation);    
        }
    }
    void OnMove(InputValue value)
    {
        if(!isAlive){return;}
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!isAlive){return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}
         if(value.isPressed) 
         {
            myRigidBody.velocity+= new Vector2(0f, jumpSpeed);
         }
    }

    void OnPause()
    {
        levelManager.LoadPauseMenu();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveVelocity, myRigidBody.velocity.y);;
        myRigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x)> Mathf.Epsilon;
            myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x)> Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
        transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x),1f);
        }
    }

    void ClimbLadder()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, moveInput.y *climbVelocity);   
            myAnimator.SetBool("isClimbing", (moveInput.y!=0));
            myRigidBody.gravityScale = 0;
        }
       else{
        myAnimator.SetBool("isClimbing", false);
        myRigidBody.gravityScale = gravityScaleAtStart;
       }
    
    }

    void Die()
        {
            if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard")))
            {
                isAlive = false;
                myAnimator.SetTrigger("Dying");
                myRigidBody.velocity+= deathkick;
                FindObjectOfType<GameSession>().ProcessPlayerDeath();
            }
            

        }

}
