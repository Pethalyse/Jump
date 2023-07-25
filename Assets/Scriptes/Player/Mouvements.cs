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
    private bool canJump = true;
    private bool canJumpDash = false;

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

            if ((canJump || canJumpDash) && Input.GetButtonDown("Jump"))
            {
                //jump
                if(!canJumpDash)
                {
                    canJumpDash = true;
                }
                else
                {
                    canJumpDash = false;
                }
                canJump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {

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

    private void isGrounded()
    {
        float extra = .02f;

        //raycast pour verifier si le joueur est au sol ou non
        RaycastHit2D hitD = Physics2D.Raycast(coll.bounds.center, Vector2.down, coll.bounds.extents.y + extra, jumpableGround);

        //raycast pour verifier si le joueur touche le mur gauche
        RaycastHit2D hitL = Physics2D.Raycast(coll.bounds.center, Vector2.left, coll.bounds.extents.x + extra, jumpableGround);

        //raycast pour verifier si le joueur touche le mur droit
        RaycastHit2D hitR = Physics2D.Raycast(coll.bounds.center, Vector2.right, coll.bounds.extents.x + extra, jumpableGround);

        //Verification visuel
        Color rayColorD;
        if(hitD.collider != null) { rayColorD = Color.green; }
        else { rayColorD = Color.red; }

        Color rayColorL;
        if (hitL.collider != null) { rayColorL = Color.blue; }
        else { rayColorL = Color.red; }

        Color rayColorR;
        if (hitR.collider != null) { rayColorR = Color.blue; }
        else { rayColorR = Color.red; }

        Debug.DrawRay(coll.bounds.center, Vector2.down * (coll.bounds.extents.y + extra), rayColorD);
        Debug.Log(hitD.collider);

        Debug.DrawRay(coll.bounds.center, Vector2.left * (coll.bounds.extents.x + extra), rayColorL);
        Debug.Log(hitL.collider);

        Debug.DrawRay(coll.bounds.center, Vector2.right * (coll.bounds.extents.x + extra), rayColorR);
        Debug.Log(hitR.collider);


        //Si l'un des ray touche alors il peut jump
        if (hitD.collider != null || hitL.collider != null || hitR.collider != null)
        {
            canJump = true;
            canJumpDash = false;
        }
        else
        {
            canJumpDash = false;
        }
    }
}
