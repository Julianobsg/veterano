using UnityEngine;

[RequireComponent(typeof(Character2DFlip))]
public class RunnerCharacter2D : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
    [SerializeField] private float jumpForce = 400f; // Amount of force added when the player jumps.	

    [SerializeField] private bool airControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character

    private Transform groundCheck; // A position marking where to check if the player is grounded.
    private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool grounded = false; // Whether or not the player is grounded.
    private Transform ceilingCheck; // A position marking where to check for ceilings
    private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator anim; // Reference to the player's animator component.
    private Rigidbody2D myRigidbody2D;
    private Character2DFlip characterFlip;
    private void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
        myRigidbody2D = rigidbody2D;
        characterFlip = GetComponent<Character2DFlip>();
    }


    private void FixedUpdate()
    {
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        // Set the vertical animation
        anim.SetFloat("vSpeed", myRigidbody2D.velocity.y);
    }


    public void Move(float move, bool jump)
    {


        //only control the player if grounded or airControl is turned on
        if (grounded || airControl)
        {

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            myRigidbody2D.velocity = new Vector2(move * maxSpeed, myRigidbody2D.velocity.y);

            characterFlip.CheckFlip(move);
        }
        // If the player should jump...
        if (grounded && jump && anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            grounded = false;
            anim.SetBool("Ground", false);
            myRigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }


}
