using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouvements : MonoBehaviour
{


    //Components
    [Header("Components")]
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    //MOUVEMENTS
    private bool canMove = true;
    private float dirX = 0f;

    [Header("Mouvements")]
    [SerializeField] private float moveSpeed;
   
    //JUMP
    private Vector3 velocity = Vector3.zero;
    private bool canJump = true;
    private bool onGround = false;
    private bool isJumping = false;
    private bool canJumpDash = false;
    private bool onWall = false;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask jumpableGround;
 
    /*
    //GRAVITY
    private float rbGravityScale;

    [Header("Gravity")]
    [SerializeField] private float rbGravityMult;
    [SerializeField] private float rbMaxFallSpeed;
    */

    enum MouvementState {idle, running, jumping, falling}

    private void Start()
    {
        //rbGravityScale = rb.gravityScale;

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        isGrounded();

        if (canMove)
        {
            //mouvement
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

            if ((onGround || onWall) && Input.GetButtonDown("Jump"))
            {
                //jump
                canJumpDash = true;
                isJumping = true;
                onGround = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {

                if (isJumping && canJumpDash && Input.GetButtonDown("Jump"))
                {
                    //jump dash
                    canJumpDash = false;
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                }

                /*
                //Si le joueur tombe
                else if (rb.velocity.y < 0)
                {

                    
                    //une gravité plus grande s'il tombe
                    setGravityScale(rb.gravityScale * rbGravityMult);
                    

                }
                else
                {
                    rb.gravityScale = rbGravityScale;
                }*/
            }
        }

    }

    /*private void setGravityScale(float v)
    {
        v = Mathf.Min(v, rbMaxFallSpeed);
        rb.gravityScale = v;
    }*/

    private void updateAnimationState()
    {
        
    }

    private bool isGrounded()
    {

        if(Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround))
        {
            Debug.Log("Sol");

            onGround = true;
            isJumping = false;
            canJumpDash = false;
            onWall = false; 

            return true;

        }
        else if(Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .1f, jumpableGround) || Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .1f, jumpableGround))
        {
            

            if(dirX > 0) { Debug.Log("Mur droite"); }else if( dirX < 0) { Debug.Log("Mur gauche"); }

            onGround = false;
            isJumping = false;
            canJumpDash = false;
            onWall = true;

            return true;
        }

        return false;
    }
}
